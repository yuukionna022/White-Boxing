using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject player;
    public GrabScript grabscript;
    public PuzzleConditions conditions;

    void OnTriggerEnter(Collider Col){ 

        if(Col == player.GetComponent<Collider>() && conditions.getPuzzleOne()){
            Debug.Log("drop");
            grabscript.Drop();
        }

    }
    



}
