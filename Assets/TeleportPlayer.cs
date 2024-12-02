using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject storePosition;
    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3(25.5805054, 7.94321632, -3.22506523)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleportPlayer()
    {
        //store the player position
        storePosition.transform.position = player.transform.position;
        //teleport the player
        player.transform.position = destination;
    }
    public void teleportPlayerBack()
    {
        player.transform.position = storePosition.transform.position;

    }
}
