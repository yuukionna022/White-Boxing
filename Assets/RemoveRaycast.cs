using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RemoveRaycast : MonoBehaviour
{
    public PuzzleConditions conditions;
    public GameObject raycastL, raycastR, player;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other == player)
        {
            raycastL.GetComponent<XRInteractorLineVisual>().enabled = false;
            raycastR.GetComponent<XRInteractorLineVisual>().enabled = false;
        }
    }
}
