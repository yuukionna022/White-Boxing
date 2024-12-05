using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeSound : MonoBehaviour
{
    public HingeJoint leftHinge;         // Left hinge HingeJoint
    public HingeJoint rightHinge;        // Right hinge HingeJoint
    public AudioSource audioSource;   
    public AudioClip movingSound;       
    private float previousLeftAngle = 0f; 
    private float previousRightAngle = 0f; 
    private bool isPlaying = false;    

    void Start()
    {

        if (leftHinge == null || rightHinge == null)
        {
            Debug.LogError("Both hinges must be assigned!");
            return;
        }


        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }


        audioSource.Stop();
        isPlaying = false;
    }

    void Update()
    {
        float currentLeftAngle = leftHinge.angle;
        float currentRightAngle = rightHinge.angle;

        Debug.Log($"loggCurrent Left Angle: {currentLeftAngle}, Current Right Angle: {currentRightAngle}");


        bool isLeftHingeMoving = Mathf.Abs(currentLeftAngle - previousLeftAngle) > 0.2f;
        bool isRightHingeMoving = Mathf.Abs(currentRightAngle - previousRightAngle) > 0.2f;

        Debug.Log($"loggLeft Hinge Moving: {isLeftHingeMoving}, Right Hinge Moving: {isRightHingeMoving}");


        if ((isLeftHingeMoving || isRightHingeMoving) && !isPlaying)
        {
            Debug.Log("loggPlaying Sound: Door is moving");
            audioSource.loop = true;            
            audioSource.PlayOneShot(movingSound); 
            isPlaying = true;
        }

        if (!isLeftHingeMoving && !isRightHingeMoving && isPlaying)
        {
            audioSource.Stop(); 
            isPlaying = false;
        }


        previousLeftAngle = currentLeftAngle;
        previousRightAngle = currentRightAngle;
    }
}
