using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{
    
    public PuzzleConditions puzzle;
    public key key;


    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(key.key_grabbed())
        {
            //Debug.Log("true");
            puzzle.setPuzzleOne(true);
       
        }
    }


    


}
