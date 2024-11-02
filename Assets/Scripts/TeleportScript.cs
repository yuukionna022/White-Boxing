using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform teleportationTarget;
    public GameObject player;

    void OnTriggerEnter(Collider Col)
    {
        Debug.Log("entered");
        player.transform.position = teleportationTarget.position;
    }
}
