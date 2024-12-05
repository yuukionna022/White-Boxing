using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSound : MonoBehaviour
{
    public AudioClip[] pickupSounds;
    public AudioSource audioSource;
    public XRGrabInteractable grabInteractable;
    private bool wasGrabbed = false;

    public float minPitch = 0.7f;
    public float maxPitch = 0.9f;

    void Start()
    {

    }

    void Update()
    {
        if (grabInteractable.isSelected)
        {
            if (!wasGrabbed)
            {
                playSound();
                wasGrabbed = true;
            }
        }
        else
        {
            wasGrabbed = false; 
        }
        
    }

    void playSound()
    {
        audioSource.pitch = Random.Range(minPitch, maxPitch);

        int randomIndex = Random.Range(0, pickupSounds.Length);
        AudioClip randomClip = pickupSounds[randomIndex];

        audioSource.PlayOneShot(randomClip);

    }
}
