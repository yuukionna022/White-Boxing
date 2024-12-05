using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodKey : Keys
{

    protected override void Update()
    {
        base.Update();

        if (grabbed)
        {

        }
    }

    public override void Ending()
    {
        base.Ending();
        ending.SetActive(true);
        Debug.Log("Good ending");
    }


}
