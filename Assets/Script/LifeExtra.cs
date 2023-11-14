using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeExtra : MonoBehaviour
{
    public AudioClip lifeUpSound;
    public float maxVolume = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ghostface player = collision.GetComponent<Ghostface>();

            if (player != null)
            {
                // Aumenta la vida del jugador
                if (player.lives < 5)
                {
                    player.AddLife();

                    // Reproduce el sonido
                    PlayLifeUpSound();

                    // Destruye el objeto del power-up
                    Destroy(gameObject);
                }
            }
        }
    }

    private void PlayLifeUpSound()
    {
        if (lifeUpSound != null)
        {
            // Crea un nuevo objeto AudioSource para reproducir el sonido
            GameObject audioSourceObject = new GameObject("LifeUpAudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.clip = lifeUpSound;
            audioSource.volume = maxVolume;

            // Reproduce el sonido
            audioSource.Play();

            // Destruye el objeto AudioSource después de 5 segundos
            Destroy(audioSourceObject, 3.5f);
        }
    }
}