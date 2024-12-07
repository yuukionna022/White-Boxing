using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DropMenuBook : MonoBehaviour
{

    public Collider roomCollider;
    public PuzzleConditions conditions;
    public TeleportPlayer teleporter;
    private Vector3 orig;

    void Start()
    {
        orig = gameObject.transform.position; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == roomCollider)
        {
            if ((conditions.getState() == 1 && conditions.getPuzzleOne()) || (conditions.getState() == 2 && conditions.getPuzzleTwo()) || (conditions.getState() == 3 && conditions.getPuzzleThree())) { 
            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            }
        }
    }

    private void Update()
    {
        if (teleporter.Teleporting())
        {
            StartCoroutine("Pause");
        }
    }

    IEnumerator Pause()
    {
        gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        gameObject.transform.position = orig;
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
    }
}
