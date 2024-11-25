using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockDoor : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject player, rigidDoor, barrier1, otherDoor, knob1;
    public TeleportFirstRoom room;

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {
           
            knob1.GetComponent<XRGrabInteractable>().enabled = false;
            otherDoor.SetActive(false);
            rigidDoor.SetActive(true);
            barrier1.SetActive(true);
            if (conditions.getPuzzleOne() && !conditions.getPuzzleTwo())
            {
                room.teleportRoom();
            }
        }
    }
}
