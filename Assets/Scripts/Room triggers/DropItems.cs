using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject player;
  //  public GrabScript grabscript;
    public PuzzleConditions conditions;
    //[SerializeField] BookGrabbable script;
    protected bool collided = false;
    public AudioSource audioSource;
    public AudioClip unlockSound;


    void OnTriggerEnter(Collider Col)
    { 
        if(Col == player.GetComponent<Collider>()){
            // Debug.Log("drop");
            // grabscript.Drop();
            //script.Drop();
            if (conditions.getState() == 1 && conditions.getPuzzleOne())
            {
                collided = true;
                audioSource.PlayOneShot(unlockSound);
            }
            //else if (conditions.getState() == 2 && conditions.getPuzzleTwo())
            //{
            //    collided = true;
            //}

        }

    }

    public bool GetCollided()
    {
        return collided;
    }
    



}
