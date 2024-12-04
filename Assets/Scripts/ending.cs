using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ending : MonoBehaviour
{

    public Collider player;
    public Keys good, bad;
    private Keys final;
    public Collider barrier;
    public GameObject rigidDoor, exitDoor;

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
        
        
        if (Col == player)
        {
            final.Ending();
            barrier.enabled = false;
            rigidDoor.SetActive(false);
            exitDoor.SetActive(true);
        }
    }
}
