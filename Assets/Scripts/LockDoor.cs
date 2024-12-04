using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockDoor : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject player, rigidDoor, barrier1, otherDoor, knob1;
    public TeleportFirstRoom room;
    public TeleportRoom room2;
    public GameObject self;

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {

            if (!conditions.getPuzzleTwo() || self.name == "third lock door") { 
            knob1.GetComponent<XRGrabInteractable>().enabled = false;
            otherDoor.SetActive(false);
            rigidDoor.SetActive(true);
            barrier1.SetActive(true);
            room.teleportRoom();
            }
            
            //if (conditions.getPuzzleOne() && !conditions.getPuzzleTwo())
            //{
            //    room.teleportRoom();
            //   // self.SetActive(false);
                
            //} 
            if(self.name == "third lock door" && conditions.getPuzzleTwo())
            {
                room2.teleportSecondTime();
            }
        }
    }
}
