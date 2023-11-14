using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int health = 1;
    public Animator anim;

    //Speed
    public GameObject powerUpPrefab;
    public float powerUpChance = 0.5f;

    public Vector3 powerUpOffset = new Vector3 (1f, 0, 0);

    private bool isDead = false;

    //Dash 
    public GameObject dashPowerUpPrefab;
    public float dashPowerUpChance = 0.3f;

    //Immortality
    public float immortalityPowerUpChance = 0.1f;
    public GameObject inmortalityPowerUpPrefab;

    //Sound
    public AudioClip deathSound;
    public float soundDuration = 3.5f;
    public float maxVolume = 0.2f;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if(health <= 0 && !isDead)
        {
            Die();
            isDead = true;
        }
    }

    void Die()
    {

        anim.SetBool("IsDead", true);

        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        //Run upgrade
        if (Random.value <= powerUpChance)
        {
            Vector3 spawnPosition = transform.position + powerUpOffset;
            Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        }

        //Inmortality
        if (Random.value <= immortalityPowerUpChance)
        {
            Vector3 spawnPosition = transform.position + powerUpOffset;
            Instantiate(inmortalityPowerUpPrefab, spawnPosition, Quaternion.identity);
        }

        //Dash 
        if(Random.value <= dashPowerUpChance)
        {
            Vector3 spawnPosition = transform.position + powerUpOffset;
            Instantiate(dashPowerUpPrefab, spawnPosition, Quaternion.identity);
        }

        PlayDeathSound();
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
