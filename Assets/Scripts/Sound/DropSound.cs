using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DropSound : MonoBehaviour
{
    public AudioSource audioSource;  // The AudioSource component
    public AudioClip collisionSound; // The sound to play when a collision occurs

    private bool hasPlayedSound = false; // Flag to ensure sound plays only once

    void Start()
    {
        // Ensure the AudioSource component is attached
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object on the "floor" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("floor") && !hasPlayedSound)
        {
            // Play the collision sound once
            audioSource.PlayOneShot(collisionSound);
            
            // Set the flag to true so the sound doesn't play again
            hasPlayedSound = true;
        }
    }

    // Optional: Reset flag when the object leaves the floor (if needed)
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("floor"))
        {
            hasPlayedSound = false; // Reset so sound can play again next time it collides with the floor
        }
    }
}

