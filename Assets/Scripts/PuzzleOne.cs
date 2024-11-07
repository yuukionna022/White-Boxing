using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{
    public GameObject player;
    public PuzzleConditions puzzle;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - player.transform.position).sqrMagnitude < 25.0f)
        {
            Debug.Log("true");
            puzzle.setPuzzleOne(true);
        }
    }

    


}
