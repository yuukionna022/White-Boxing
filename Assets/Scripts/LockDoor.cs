using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject player, rigidDoor, barrier1, otherDoor;
    public TeleportFirstRoom room;

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {
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
