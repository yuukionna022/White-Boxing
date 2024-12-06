using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{   
    public BoxCollider playerCollider;
    public BoxCollider floorCollider;

    private void Update()
    {
       
        if (AreCollidersTouching(playerCollider, floorCollider))
        {
          //  Debug.Log("The colliders are touching!");
          
        }
        else
        {
          //  Debug.Log("The colliders are not touching.");
        }
    }

  
    private bool AreCollidersTouching(BoxCollider collider1, BoxCollider collider2)
    {
    
        return collider1.bounds.Intersects(collider2.bounds);
    }
}
