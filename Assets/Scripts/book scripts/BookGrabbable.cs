using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookGrabbable : MonoBehaviour
{
    ObjectStateScript currentState;
    public GameObject player, book;
    public DropItems barrier;


    // Start is called before the first frame update
    void Start()
    {
        currentState = new Dropped(GetComponent<XRGrabInteractable>(), player, book);
    }

    // Update is called once per frame
    void Update()
    {
        if (barrier.GetCollided())
        {
            Drop();
        }
        currentState = currentState.Process();
        //Debug.Log(currentState.name);
        if (Grabbed())
        {
            Debug.Log(currentState.interactable.gameObject.name);
        }

    }

    private void Drop()
    {
        currentState.Drop();
    }

    public bool Grabbed()
    {
        return (currentState.Grabbed());
    }
}
