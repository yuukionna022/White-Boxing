using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSoundGround : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] collisionSounds;
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;
    public float soundCooldown = 0.8f;

    private bool canPlaySound = true;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        CheckInitialContact();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("floor") && canPlaySound)
        {
            PlayRandomSound();
            StartCoroutine(SoundCooldown());
        }
    }

    void PlayRandomSound()
    {
        if (collisionSounds.Length == 0) return;

        int randomIndex = Random.Range(0, collisionSounds.Length);
        AudioClip randomClip = collisionSounds[randomIndex];

        audioSource.pitch = Random.Range(minPitch, maxPitch);
        audioSource.PlayOneShot(randomClip);
    }

    IEnumerator SoundCooldown()
    {
        canPlaySound = false;
        yield return new WaitForSeconds(soundCooldown);
        canPlaySound = true;
    }

    void CheckInitialContact()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("floor"))
            {
                canPlaySound = false;
                StartCoroutine(ResetSoundAfterDelay());
                break;
            }
        }
    }

    IEnumerator ResetSoundAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        canPlaySound = true;
    }
}
