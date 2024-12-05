using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightIn : MonoBehaviour
{

    public Collider door;
    public GameObject lights;

    private void OnTriggerEnter(Collider other)
    {
        if (other == door)
        {

            lights.SetActive(true);
        }
    }
}
