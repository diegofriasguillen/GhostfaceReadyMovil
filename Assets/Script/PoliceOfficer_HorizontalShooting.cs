using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer_HorizontalShooting : MonoBehaviour
{
    [SerializeField] private PatrolNPCS _patrol;
    [SerializeField] private NPCPoints npcPoints;

    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float shootingRange = 5f;
    public float shootingInterval = 5f;
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

    //SoundDead
    public AudioClip deathSound;
    public float soundDuration = 3.5f;
    public float maxVolume = 0.2f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = shootVolume;

        //patrullar 
        if (_patrol == null)
        {
            _patrol = GetComponent<PatrolNPCS>();
        }
    }

    private void Update()
    {
        if (!isAlive)
        {
            return;
        }

        Collider2D ghostfaceCollider = Physics2D.OverlapCircle(shootingPoint.position, shootingRange, LayerMask.GetMask("Ghostface"));

        if (ghostfaceCollider && !isShooting)
        {
            Vector2 directionToGhostface = ghostfaceCollider.transform.position - transform.position;

            FlipCharacterDirection(directionToGhostface.x);

            StartCoroutine(Shoot(ghostfaceCollider.transform));

            if (_patrol != null)
            {
                _patrol.StopPatrol();
            }
        }
    }

    private IEnumerator Shoot(Transform targetTransform)
    {
        isShooting = true;
        animator.SetTrigger("StartShooting");

        Debug.Log("Shooting from: " + shootingPoint.position);

        Vector2 direction = new Vector2(-1, 0);

        GameObject bulletObject = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
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
        if (!isAlive)
        {
            return;
        }

        policeLives -= damageAmount;

        if (policeLives <= 0)
        {
            npcPoints.KillNPC();
            Die();
        }
    }

    private void FlipCharacterDirection(float targetDirectionX)
    {
        if ((targetDirectionX > 0 && transform.localScale.x < 0) ||
            (targetDirectionX < 0 && transform.localScale.x > 0))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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

        PlayDeathSound();

        //Patrullar
        if (_patrol != null)
        {
            _patrol.enabled = false;
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(shootingPoint.position, shootingRange);
    }

    private void PlayDeathSound()
    {
        if (deathSound != null)
        {
            GameObject audioSourceObject = new GameObject("DeathAudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.clip = deathSound;
            audioSource.volume = maxVolume;

            audioSource.Play();

            Destroy(audioSourceObject, soundDuration);
        }
    }
}