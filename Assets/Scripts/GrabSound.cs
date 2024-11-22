using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabSound : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioSource audioSource;
    public XRGrabInteractable grabInteractable;
    private bool wasGrabbed = false;

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
        if (pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
    }
}
