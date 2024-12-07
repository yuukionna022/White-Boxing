using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject storePosition;
    //public Vector3 destination;
    public GameObject destinationObject, screen, menu;
    public float transitionTime;
    private float slider;
    private bool teleportingPlayer;
    private Quaternion storeRotation;
    private bool teleportingPlayerBack;
    // Start is called before the first frame update
    void Start()
    {
        slider = 0;
        teleportingPlayer = false;
        teleportingPlayerBack = false;
        storeRotation = storePosition.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportingPlayer == true)
        {



            //Debug.Log("teleport Player");
            slider += Time.deltaTime / transitionTime;
            if (slider >= 0.5)
            {
                //teleport the player
                player.transform.position = destinationObject.transform.position;


                if (destinationObject.name == "MenuDestination")
                {
                    player.transform.position = destinationObject.transform.position;

                    //Debug.Log("look");
                    var look = screen.transform.position - player.transform.position;
                    look.y = 0;
                    var rotation = Quaternion.LookRotation(look);
                    player.transform.rotation = rotation;
                }

                //} else if (destinationObject.name == "PlayGameDestination")
                //{
                //    var xrCam = Camera.main.transform;
                //    var offset = xrCam.localPosition;

                //    player.transform.position = destinationObject.transform.position - offset;
                //} else
                //{
                //    player.transform.position = destinationObject.transform.position;
                //}


                teleportingPlayer = false;
            }
        }
        if (teleportingPlayerBack)
        {
            slider += Time.deltaTime / transitionTime;
            if (slider >= 0.5)
            {
                player.transform.position = storePosition.transform.position;
                player.transform.rotation = storeRotation;

                teleportingPlayerBack = false;
            }
        }

        //reset timer
        if (!teleportingPlayer && !teleportingPlayerBack)
        {
            slider = 0;
        }
    }

    public void teleportPlayer()
    {
        storePosition.transform.position = player.transform.position;
        storeRotation = Quaternion.LookRotation(player.transform.position);
        teleportingPlayer = true;
    }
    public void teleportPlayerBack()
    {
        teleportingPlayerBack = true;
    }

    public bool Teleporting()
    {
        return teleportingPlayer;
    }
}
