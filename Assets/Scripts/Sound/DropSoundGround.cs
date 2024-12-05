using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSoundGround : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip collisionSound;

    private bool hasPlayedSound = true;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("floor") && !hasPlayedSound)
        {
            audioSource.PlayOneShot(collisionSound);

            hasPlayedSound = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("floor"))
        {
            hasPlayedSound = false;
        }
    }
}

