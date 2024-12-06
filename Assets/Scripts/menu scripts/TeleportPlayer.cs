using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject storePosition;
    //public Vector3 destination;
    public GameObject destinationObject;
    public float transitionTime;
    private float slider;
    private bool teleportingPlayer;
    private Quaternion angle;
    // Start is called before the first frame update
    void Start()
    {
        slider = 0;
        angle = new Quaternion(0, 0, 0, 1);
        teleportingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportingPlayer == true)
        {
            Debug.Log("teleport Player");
            slider += Time.deltaTime / transitionTime;
            if (slider >= 0.5)
            {
                //store the player position
                storePosition.transform.position = player.transform.position;
                //teleport the player
                player.transform.position = destinationObject.transform.position;
                if (player.transform.rotation != angle)
                {
                    player.transform.rotation = angle;
                }

                teleportingPlayer = false;
            }
        }
        else
        {
            slider = 0;
        }
    }

    public void teleportPlayer()
    {
        teleportingPlayer = true;
    }
    public void teleportPlayerBack()
    {
        slider += Time.deltaTime / transitionTime;
        if (slider >= 2)
        {
            player.transform.position = storePosition.transform.position;
        }
    }
}
