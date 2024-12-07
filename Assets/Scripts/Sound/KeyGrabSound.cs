using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyGrabSound : MonoBehaviour
{
    public AudioClip[] pickupSounds;
    public AudioSource audioSource;
    public XRGrabInteractable grabInteractable;
    public BookGrabbable bookGrabbable;
    private bool wasGrabbed = false;

    public float minPitch = 0.7f;
    public float maxPitch = 0.9f;

    void Start()
    {

    }

    void Update()
    {
         if (bookGrabbable != null && bookGrabbable.Grabbed())
        {
            if (!wasGrabbed)
            {
                playSound();
                wasGrabbed = true;
                Debug.Log("Grabbed object and played sound");
            }
        }
        else
        {
            wasGrabbed = false; //reset
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
