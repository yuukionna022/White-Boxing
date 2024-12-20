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
    public GameObject rigidDoor, exitDoor, goodKey, badKey;
    public PuzzleConditions conditions;
    private bool drop = false;
    public AudioSource audioSource;
    public AudioClip unlockSound;
    private bool playedSound = false;

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
            //Play unlock sound
            if(!playedSound){
                audioSource.PlayOneShot(unlockSound);
                playedSound = true;
            }
            

            final.Ending();
            //Debug.Log("final door opened");
            barrier.enabled = false;
            rigidDoor.SetActive(false);
            exitDoor.SetActive(true);
            goodKey.SetActive(false);
            badKey.SetActive(false);
            //goodKey.GetComponent<XRGrabInteractable>().enabled = false;
            //badKey.GetComponent<XRGrabInteractable>().enabled = false;
            //goodKey.GetComponent<MeshRenderer>().enabled = false;
            //badKey.GetComponent<MeshRenderer>().enabled = false;
            drop = true;
        }
    }

    public bool Drop()
    {
        return drop;
    }
    public void setDrop(bool setting)
    {
        drop = setting;
    }
}
