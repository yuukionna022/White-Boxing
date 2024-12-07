using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DropMenuBook : MonoBehaviour
{

    public Collider roomCollider;
    public PuzzleConditions conditions;
    public TeleportPlayer teleporter;
    private Vector3 one, two, three;

    void Start()
    {
       one = new Vector3(55.80258560180664f, 0.5442066192626953f, 4.880788803100586f);
       two = new Vector3(63.58655548095703f, 0.36991643905639653f, -3.430189609527588f);
       three = new Vector3(57.515750885009769f, 0.05655479431152344f, 8.976882934570313f);
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
        if (conditions.getState() == 0)
        {
            gameObject.transform.position = one;
        }
        else if (conditions.getState() == 1)
        {
            gameObject.transform.position = two;
        }
        else 
        {
            gameObject.transform.position = three;
        }
        yield return new WaitForSeconds(0.02f);
        gameObject.GetComponent<XRGrabInteractable>().enabled = true;
    }
}
