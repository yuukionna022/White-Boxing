using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public HingeJoint hinge;
    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;
    //private float previousAngle = 0f;
    public float openThreshold = -30f;
    public float closeThreshold = -1f;
    private bool hasPlayedOpenSound = false;
    private bool hasPlayedCloseSound = true;

    void Start()
    {
        if (hinge == null)
            hinge = GetComponent<HingeJoint>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
         Debug.Log("Hinge Angle: " + hinge.angle);
        float currentAngle = hinge.angle;

        if (currentAngle <= openThreshold && !hasPlayedOpenSound)
        {
            audioSource.clip = openSound;
            audioSource.Play();
            hasPlayedOpenSound = true;
        }

        if (currentAngle >= closeThreshold && !hasPlayedCloseSound)
        {
            audioSource.clip = closeSound;
            audioSource.Play();
            hasPlayedCloseSound = true;
        }
    }
}
