using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GoodKey : Keys
{
    public GameObject child;
    protected override void Update()
    {
        base.Update();

        if (grabbed)
        {
            child.GetComponent<MeshRenderer>().enabled = true;
        } 
    }

    public override void Ending()
    {
        base.Ending();
        ending.SetActive(true);
        Debug.Log("Good ending");
    }

    protected override void OnReleased(SelectExitEventArgs args)
    {
        child.GetComponent<MeshRenderer>().enabled = false;
        grabbed = false;
    }

}
