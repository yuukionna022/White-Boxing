using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FinalDoorLock : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject player, image, barrier1, otherDoor, knob1;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {

            if (!conditions.getPuzzleThree())
            {
                knob1.GetComponent<XRGrabInteractable>().enabled = false;
                otherDoor.SetActive(false);
                image.SetActive(true);
                barrier1.SetActive(true);          
            }
        }
    }
}
