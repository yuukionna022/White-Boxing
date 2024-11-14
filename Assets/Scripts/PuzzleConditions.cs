using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleConditions : MonoBehaviour
{

    private bool puzzleOne = false;
    private bool puzzleTwo = false;
    private int state = 0;


    public bool getPuzzleOne()
    {
        return puzzleOne;
    }

    public bool getPuzzleTwo()
    {
        return puzzleTwo;
    }

    public int getState()
    {
        return state;
    }

    public void setPuzzleOne(bool condition)
    {
        puzzleOne = condition;

    }

    public void setPuzzleTwo(bool condition)
    {
        puzzleOne = condition;
    }

    public void setState(int x)
    {
        state = x;
    }
}
