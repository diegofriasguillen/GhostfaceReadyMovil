using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float shootingRange = 5f;
    public float shootingInterval = 1f;
    private Animator animator;
    private bool isShooting = false;

    public int policeLives = 2;
    private bool isAlive = true;

    //Extralife
    public GameObject lifeExtraPrefab;
    public int dropProbability = 100;
    public Vector3 powerUpOffset = new Vector3(1f, 0, 0);

    // Agregado para el sonido
    public AudioClip shootSound;
    private AudioSource audioSource;
    public float shootVolume = 0.1f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = shootVolume;
    }

    private void Update()
    {
        if(!isAlive)
        {
            return;
        }

        Collider2D ghostfaceCollider = Physics2D.OverlapCircle(shootingPoint.position, shootingRange, LayerMask.GetMask("Ghostface"));

        if (ghostfaceCollider && !isShooting)
        {
            StartCoroutine(Shoot(ghostfaceCollider.transform));
        }
    }

    private IEnumerator Shoot(Transform targetTransform)
    {
        isShooting = true;
        animator.SetTrigger("StartShooting");

        Vector2 direction = (targetTransform.position - shootingPoint.position).normalized;

        Bullet bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.SetDirection(direction);

        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound, shootVolume);
        }

        yield return new WaitForSeconds(shootingInterval);
        animator.ResetTrigger("StartShooting");
        isShooting = false;

        
    }

    public void TakeDamage(int damageAmount)
    {
        if(!isAlive)
        {
            return;
        }

        policeLives -= damageAmount;

        if(policeLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        animator.SetTrigger("Die");
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().isTrigger = true;

        //Extralife
        int randomChance = Random.Range(1, 101); 
        if (randomChance <= dropProbability) 
        {
            Vector3 spawnPosition = transform.position + powerUpOffset;
            Instantiate(lifeExtraPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shootingPoint.position, shootingRange);
    }
}
