using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedMultiplier = 2f;
    public float duration = 20f;

    //sound
    public AudioClip powerUpSound;
    public float maxVolume = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Ghostface player = collision.GetComponent<Ghostface>();

            if (player != null)
            {
                StartCoroutine(ActivatePowerUp(player));

                PlayPowerUpSound();

                Destroy(gameObject);
            }
        }
    }

    private IEnumerator ActivatePowerUp(Ghostface player)
    {
        player.ActivateSpeedPowerUp();

        yield return new WaitForSeconds(duration);

        player.moveSpeed /= speedMultiplier;
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

            Destroy(audioSourceObject, 3.5f);
        }
    }
}