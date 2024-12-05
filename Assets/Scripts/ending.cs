using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ending : MonoBehaviour
{

    public Collider player;
    public Keys good, bad;
    private Keys final;
    public Collider barrier;
    public GameObject rigidDoor, exitDoor;
    public PuzzleConditions conditions;
    private bool drop = false;

    void OnTriggerEnter(Collider Col)
    {

        
        
        if (Col == player && conditions.getPuzzleThree())
        {

            if (good.GetGrabbed())
            {
                //Debug.Log("good");
                final = good;
            }
            else if (bad.GetGrabbed())
            {
                //Debug.Log("bad");
                final = bad;
            }

            final.Ending();
            Debug.Log("final door opened");
            barrier.enabled = false;
            rigidDoor.SetActive(false);
            exitDoor.SetActive(true);
            good.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            bad.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            good.gameObject.GetComponent<Renderer>().enabled = false;
            bad.gameObject.GetComponent<Renderer>().enabled = false;
            drop = true;
        }
    }

    public bool Drop()
    {
        return drop;
    }
}
