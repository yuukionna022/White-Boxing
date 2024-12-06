using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodEnding : EndingTransition
{

    // Update is called once per frame
    protected override void OnTriggerEnter(Collider other)
    {
        SetEnabled();
        base.OnTriggerEnter(other);
    }
}
