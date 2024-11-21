using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{

    public AudioSource footstepSource;
    public AudioClip[] footstepClips; //array of footstep clips
    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;


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
        bool isKeyboardMoving = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");

        //occulus input?
        //float horizontal = Input.GetAxis("Oculus_GearVR_LThumbstickHorizontal");
        //float vertical = Input.GetAxis("Oculus_GearVR_LThumbstickVertical");

        //return isKeyboardMoving || Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;
        return isKeyboardMoving;

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
