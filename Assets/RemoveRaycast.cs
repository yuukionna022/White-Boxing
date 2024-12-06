using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RemoveRaycast : MonoBehaviour
{

    public GameObject raycastL, raycastR;
    private void OnTriggerEnter(Collider other)
    {
        raycastL.GetComponent<XRInteractorLineVisual>().enabled = false;
        raycastR.GetComponent<XRInteractorLineVisual>().enabled = false;
    }
}
