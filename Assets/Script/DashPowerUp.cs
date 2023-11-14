using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPowerUp : MonoBehaviour
{
    public AudioClip powerUpSound;
    public float soundDuration = 5f;
    public float maxVolume = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ghostface player = collision.GetComponent<Ghostface>();

            if (player != null)
            {
                player.ActivateDash();

                PlayPowerUpSound();

                Destroy(gameObject);
            }
        }
    }

    private void PlayPowerUpSound()
    {
        if (powerUpSound != null)
        {
            GameObject audioSourceObject = new GameObject("PowerUpAudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.clip = powerUpSound;
            audioSource.volume = maxVolume;

            audioSource.Play();

            Destroy(audioSourceObject, soundDuration);
        }
    }
}
