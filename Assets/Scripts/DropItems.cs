using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject player;
  //  public GrabScript grabscript;
    public PuzzleConditions conditions;
    //[SerializeField] BookGrabbable script;
    private bool collided = false;

    void OnTriggerEnter(Collider Col){ 

        if(Col == player.GetComponent<Collider>() && conditions.getPuzzleOne()){
            Debug.Log("drop");
            // grabscript.Drop();
            //script.Drop();
            collided = true;
        }

    }

    public bool GetCollided()
    {
        return collided;
    }
    



}
