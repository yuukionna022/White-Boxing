using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookGrabbable : MonoBehaviour
{
    ObjectStateScript currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new Grabbable(GetComponent<XRGrabInteractable>());
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        Debug.Log(currentState.name);
    }
}
