using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FootballPlayer : MonoBehaviour
{
    [SerializeField] private NPCPoints npcPoints;

    public GameObject ballPrefab;
    public float throwForce = 10f;
    public float throwInterval = 2f;
    private Transform target;
    private bool isThrowing = false;
    public int lives = 3;
    public float detectionRange = 10f;
    private Animator animator;
    private bool isAlive = true;


    //SoundDead
    public AudioClip deathSound;
    public float soundDuration = 3.5f;
    public float maxVolume = 0.2f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        InvokeRepeating("ThrowBall", 0f, throwInterval);
    }

    private void Update()
    {
        if (isAlive)
        {
            bool ghostfaceDetected = false;

            Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, detectionRange, LayerMask.GetMask("Ghostface"));

            foreach (Collider2D player in hitPlayers)
            {
                if (player.CompareTag("Player"))
                {
                    ghostfaceDetected = true;
                    break;
                }
            }

            if (ghostfaceDetected && !isThrowing)
            {
                isThrowing = true;
                animator.SetTrigger("StartThrowing");
            }
            else if (!ghostfaceDetected && isThrowing)
            {
                isThrowing = false;
                animator.SetTrigger("StopThrowing");
            }
        }
        else
        {
            animator.SetTrigger("Die");
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void ThrowBall()
    {

        if (isAlive && isThrowing) // Verifica que est� en el estado de lanzamiento
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

            Vector2 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * throwForce, ForceMode2D.Impulse);

            Destroy(ball, 1f);
            isThrowing = false;
        }
    }

    private IEnumerator ResetThrowingAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta el tiempo seg�n lo que funcione mejor en tu juego
        animator.SetBool("IsThrowingBall", false);
    }
    public void StartThrowing()
    {
        InvokeRepeating("ThrowBall", 0f, throwInterval);
    }

    public void StopThrowing()
    {
        CancelInvoke("ThrowBall");
    }

    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
            lives -= damage;

            if (lives <= 0)
            {
                npcPoints.KillNPC();
                Die();
            }
        }
    }

    private void ResetThrowing()
    {
        isThrowing = false;
    }

    private void Die()
    {
        isAlive = false;
        animator.SetTrigger("IsDead");
        GetComponent<Collider2D>().enabled = false;

        PlayDeathSound();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
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