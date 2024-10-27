using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; 

public class OpenClosetDoor : MonoBehaviour
{
    public Camera cam;
    private Transform selectedDoor;
    private GameObject dragPoint;
    private int leftdoor = 0;
    public LayerMask doorLayer;
    public InputDevice device;

    void Start()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        device = inputDevices[0];
    }
    
    
    // Update is called once per frame
    void Update()
    {

        bool triggerValue;
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
        }


        //RaycastHit hit;

        //if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, 20, doorLayer))
        //{
        //    //if(Input.)
        //}
    }
}
