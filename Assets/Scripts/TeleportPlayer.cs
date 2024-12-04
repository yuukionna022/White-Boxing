using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject storePosition;
    //public Vector3 destination;
    public GameObject destinationObject;
    // Start is called before the first frame update
    void Start()
    {
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":-33.35050582885742,"y":0.7750000953674316,"z":-13.514934539794922},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.0,"y":1.0,"z":1.0} }
        //-33.35050582885742,"y":0.7750000953674316,"z":-13.514934539794922
        //UnityEditor.TransformWorldPlacementJSON:{ "position":{ "x":103.74949645996094,"y":0.7750000953674316,"z":23.355064392089845},"rotation":{ "x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{ "x":1.0,"y":1.0,"z":1.0} }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleportPlayer()
    {
        Debug.Log("teleport Player");
        //store the player position
        storePosition.transform.position = player.transform.position;
        //teleport the player
        player.transform.position = destinationObject.transform.position;
    }
    public void teleportPlayerBack()
    {
        player.transform.position = storePosition.transform.position;

    }
}
