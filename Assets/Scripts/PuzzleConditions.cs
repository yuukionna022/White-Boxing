using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleConditions : MonoBehaviour
{

    public bool puzzleOne = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public bool getPuzzleOne()
    {
        return puzzleOne;
    }

    public void setPuzzleOne(bool condition)
    {
        puzzleOne = condition;

    }
}
