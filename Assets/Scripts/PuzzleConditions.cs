using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleConditions : MonoBehaviour
{

    public bool puzzleOne = false;


    public bool getPuzzleOne()
    {
        return puzzleOne;
    }

    public void setPuzzleOne(bool condition)
    {
        puzzleOne = condition;

    }
}
