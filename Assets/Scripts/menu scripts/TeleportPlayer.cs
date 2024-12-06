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
    // Start is called before the first frame update
    void Start()
    {
        slider = 0;
        teleportingPlayer = false;
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
                //store the player position
                //storePosition.transform.position = player.transform.position;
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
        else
        {
            slider = 0;
        }
    }

    public void teleportPlayer()
    {
        teleportingPlayer = true;
        storePosition.transform.position = player.transform.position;
    }
    public void teleportPlayerBack()
    {
        slider += Time.deltaTime / transitionTime;
        if (slider >= 2)
        {
            player.transform.position = storePosition.transform.position;
        }
    }

    public bool Teleporting()
    {
        return teleportingPlayer;
    }
}
