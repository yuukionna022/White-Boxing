using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBooks : DropItems 
{
    void OnTriggerEnter(Collider Col)
    {

        if (Col == player.GetComponent<Collider>())
        {
            // Debug.Log("drop");
            // grabscript.Drop();
            //script.Drop();
            if (conditions.getPuzzleTwo())
            {
                collided = true;
            }
            //else if (conditions.getState() == 2 && conditions.getPuzzleTwo())
            //{
            //    collided = true;
            //}

        }

    }
}
