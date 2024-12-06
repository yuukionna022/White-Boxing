using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{   
    public BoxCollider playerCollider;
    public BoxCollider floorCollider;

    private void Update()
    {
        // Check if the two colliders are touching
        if (AreCollidersTouching(playerCollider, floorCollider))
        {
            Debug.Log("The colliders are touching!");
            // Add any additional behavior here when they are touching
        }
        else
        {
            Debug.Log("The colliders are not touching.");
        }
    }

    // Function to check if two BoxColliders are touching
    private bool AreCollidersTouching(BoxCollider collider1, BoxCollider collider2)
    {
        // Check if the bounding boxes of the colliders overlap
        return collider1.bounds.Intersects(collider2.bounds);
    }
}
