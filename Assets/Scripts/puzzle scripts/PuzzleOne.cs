using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{
    
    public PuzzleConditions puzzle;
    public BookGrabbable key;

    // Update is called once per frame
    void Update()
    {
        if(key.Grabbed())
        {
            Debug.Log("true");
            puzzle.setPuzzleOne(true);
       
        }
    }


    


}
