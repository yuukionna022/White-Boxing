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

        if(final != null)
        {
            Debug.Log("final set");
        }

        if (good.GetGrabbed())
        {
            Debug.Log("good");
            final = good;
        }
        else if (bad.GetGrabbed()) 
        {
            Debug.Log("bad");
            final = bad;
        }
        
        
        if (Col == player)
        {
            final.Ending();
            Debug.Log("final door opened");
            barrier.enabled = false;
            rigidDoor.SetActive(false);
            exitDoor.SetActive(true);
        }
    }
}
