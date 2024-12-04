using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadKey : Keys
{

  public override void Ending()
    {
        ending.SetActive(true);
        Debug.Log("ending");
    }
}
