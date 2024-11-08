using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabScript : MonoBehaviour
{
    public GameObject book;
    public GameObject key;
    public GameObject player;
    private XRGrabInteractable grabbable;
    private XRGrabInteractable key_grabbable;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = book.GetComponent<XRGrabInteractable>();
        key_grabbable = key.GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - book.transform.position).magnitude < 2.5f)
        {
            grabbable.enabled = true;
            key_grabbable.enabled = true;

        }
        else
        {
            grabbable.enabled = false;
            key_grabbable.enabled = false;

        }
    }
}
