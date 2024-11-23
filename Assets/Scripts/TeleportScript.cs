using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Start is called before the first frame update

    //public Transform teleportationTarget;
    public GameObject player, rigidDoor, grabbableDoor, barrier1;
    public PuzzleConditions conditions;
    public bool teleporting = false;
    public TeleportRoom room;
    public TeleportRoomTwo room2;




    void OnTriggerEnter(Collider Col)
    {
        if (Col == player.GetComponent<CapsuleCollider>())
        {

            Debug.Log("entered");
            if (conditions.getPuzzleOne() && conditions.getState() == 0)
            {
                teleporting = true;
                room.teleportRoom();
                rigidDoor.SetActive(false);
                grabbableDoor.SetActive(true);
                Debug.Log("new door");
                barrier1.SetActive(false);
                Debug.Log("barrier gone");
                teleporting = false;
                conditions.setState(1);

            } else if (conditions.getPuzzleTwo() && conditions.getState() == 1)
            {
                teleporting = true;
                room2.teleportRoom();
                rigidDoor.SetActive(false);
                grabbableDoor.SetActive(true);
                conditions.setState(2);
                teleporting = false;
            }
        }
    }

    public bool getTeleporting()
    {
        return teleporting;
    }


}
