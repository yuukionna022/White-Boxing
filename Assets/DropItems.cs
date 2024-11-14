using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject player;
    public GrabScript grabscript;

    void OnTriggerEnter(Collider Col){ 

        if(Col == player.GetComponent<Collider>()){
            Debug.Log("drop");
            grabscript.Drop();
        }

    }
    



}
