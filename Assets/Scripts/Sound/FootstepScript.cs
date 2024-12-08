using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FootstepScript : MonoBehaviour
{

    public AudioSource footstepSource;
    public AudioClip[] footstepClips; //array of footstep clips
    public float minPitch = 0.3f;
    public float maxPitch = 0.8f;
    public Vector2 thumbstickInput;

    void Start()
    {

        
    }


    void Update()
    {
         if (isPlayerMoving() && !footstepSource.isPlaying)
        {
            playFootstep();
        }
        
    }

     private bool isPlayerMoving()
    {
        //moving with keyboard test, isMoving updates every frame
        bool isMoving;
        //isMoving = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        //occulus input test
        if (InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.primary2DAxis, out thumbstickInput))
        {
            if (thumbstickInput.magnitude > 0.1f)
            {
               // Debug.Log("Moving");
                isMoving = true;
            }
            else
            {
                //Debug.Log("Not moving");
                isMoving = false;
            }
        }
        else
        {
            // Debug.Log("Not detected.");
            isMoving = false;
        }

        return isMoving;

    }


    private void playFootstep()
    {
        //random pitch
        footstepSource.pitch = Random.Range(minPitch, maxPitch);

        //random footstep clip
        int randomIndex = Random.Range(0, footstepClips.Length);
        AudioClip randomClip = footstepClips[randomIndex];

        footstepSource.PlayOneShot(randomClip);
    }
}
