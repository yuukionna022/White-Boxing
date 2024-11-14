using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointToggle : MonoBehaviour
{
    public HingeJoint joint;
    private Rigidbody connectedBody;
    public PuzzleConditions puzzle;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        connectedBody = joint.connectedBody;
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle.getPuzzleOne())
        {
            On();
        }
        else
        {
            Off();
        }
    }

    void On()
    {
        joint.connectedBody = connectedBody;

    }

    void Off()
    {
        joint.connectedBody = null;
        connectedBody.WakeUp();
    }
}
