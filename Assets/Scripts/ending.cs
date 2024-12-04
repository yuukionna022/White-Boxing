using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ending : MonoBehaviour
{

    public GameObject player;
    public Keys good, bad, final;

    void OnTriggerEnter(Collider Col)
    {

        if (good.GetGrabbed())
        {
            final = good;
        }
        else if (bad.GetGrabbed()) 
        {
            final = bad;
        }
        
        
        if (Col == player.GetComponent<CapsuleCollider>())
        {
            final.Ending();
        }
    }
}
