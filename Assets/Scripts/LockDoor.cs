using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject player, rigidDoor, barrier1, otherDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {
            otherDoor.SetActive(false);
            rigidDoor.SetActive(true);
            barrier1.SetActive(true);
        }
    }
}
