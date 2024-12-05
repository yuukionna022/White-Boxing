using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FinalDoorLock : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject image, barrier1, otherDoor, knob1;
    public Collider player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {

            if (conditions.getPuzzleThree())
            {
                knob1.GetComponent<XRGrabInteractable>().enabled = false;
                otherDoor.SetActive(false);
                image.SetActive(true);
                barrier1.SetActive(true);          
            }
        }
    }
}
