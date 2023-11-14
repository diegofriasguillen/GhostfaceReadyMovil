using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InmortalityPowerUp : MonoBehaviour
{
    public float duration = 10f;
    public AudioClip powerUpSound;
    public float maxVolume = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ghostface player = collision.GetComponent<Ghostface>();

            if (player != null)
            {
                // Activa el power-up de inmortalidad en el jugador
                StartCoroutine(ActivatePowerUp(player));

                // Reproduce el sonido
                PlayPowerUpSound();

                // Destruye el objeto del power-up
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator ActivatePowerUp(Ghostface player)
    {
        // Activa el power-up de inmortalidad en el jugador
        player.BecomeImmortal();

        // Espera la duración del power-up
        yield return new WaitForSeconds(duration);

        // Desactiva la inmortalidad del jugador
        player.isImmortal = false;
    }

    private void PlayPowerUpSound()
    {
        if (powerUpSound != null)
        {
            // Crea un nuevo objeto AudioSource para reproducir el sonido
            GameObject audioSourceObject = new GameObject("PowerUpAudioSource");
            AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
            audioSource.clip = powerUpSound;
            audioSource.volume = maxVolume;

            // Reproduce el sonido
            audioSource.Play();

            // Destruye el objeto AudioSource después de 5 segundos
            Destroy(audioSourceObject, 3.5f);
        }
    }
}