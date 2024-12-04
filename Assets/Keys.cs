using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Keys : MonoBehaviour
{
    public XRGrabInteractable interactable;
    protected bool grabbed;
    public Keys other;
    public GameObject ending;

    // Start is called before the first frame update
    protected void Start()
    {
        interactable.selectEntered.AddListener(OnGrabbed);
        interactable.selectExited.AddListener(OnReleased);
    }

    // Update is called once per frame
   protected virtual void Update()
    {
        if (grabbed)
        {
            other.SetGrabbed();
            other.gameObject.SetActive(false);
        }
        else
        {
            other.gameObject.SetActive(true);
        }
    }
    protected void OnGrabbed(SelectEnterEventArgs args)
    {
        grabbed = true;
    }

    protected void OnReleased(SelectExitEventArgs args)
    {
        grabbed = false;
    }

    public bool GetGrabbed()
    {
        return grabbed;
    }
    protected void SetGrabbed()
    {
        grabbed = false;
    }

    public void Ending() { }
}
