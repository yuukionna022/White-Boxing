using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class FlashlightFSM 
{
    public enum STATE
    {
        HOLDING, TELEPORT, DROPPED
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject player, self;
    protected FlashlightFSM nextState;
    protected PuzzleConditions conditions;
    protected Collider playerCol;
    protected bool grabbed;
    protected ending ending;

    public FlashlightFSM(GameObject player, GameObject flashlight, ending end)
    {
        this.player = player;
        self = flashlight;
        playerCol = player.GetComponent<Collider>();
        conditions = player.GetComponent<PuzzleConditions>();
        grabbed = false;
        ending = end;
        self.GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrabbed);
        self.GetComponent<XRGrabInteractable>().selectExited.AddListener(OnReleased);
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.ENTER; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public FlashlightFSM Process()
    {
        if (stage == EVENT.ENTER) Update();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    protected void OnGrabbed(SelectEnterEventArgs args)
    {
        grabbed = true;
        //Debug.Log(grabbed);
    }

    protected void OnReleased(SelectExitEventArgs args)
    {
        grabbed = false;
        //Debug.Log(grabbed);
    }
}


public class Holding : FlashlightFSM
{
    public Holding(GameObject player, GameObject flashlight, ending end) : base(player, flashlight, end)
    {
        name = STATE.HOLDING;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {

        if (ending.Drop())
        {
            Debug.Log("drop");
            self.GetComponent<XRGrabInteractable>().enabled = false;
            self.SetActive(false);
        }

        else if (!grabbed)
        {
            nextState = new Drop(player, self, ending);
            stage = EVENT.EXIT;
        }

        
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Teleporting : FlashlightFSM
{
    protected Vector3 position;
    protected Quaternion rotation;

    public Teleporting(GameObject player, GameObject flashlight, Vector3 position, Quaternion rotation, ending end) : base(player, flashlight, end)
    {
        this.position = position;
        this.rotation = rotation;
        name = STATE.TELEPORT;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {

        self.transform.position = position;
        self.transform.rotation = rotation;
        nextState = new Drop(player, self, ending);
        stage = EVENT.EXIT;
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Drop : FlashlightFSM
{
    public Drop(GameObject player, GameObject flashlight, ending end) : base(player, flashlight, end)
    {
        name = STATE.DROPPED;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {

        if (grabbed)
        {
            nextState = new Holding(player, self, ending);
            stage = EVENT.EXIT;
        }
        
        if ((self.transform.position - player.transform.position).magnitude > 3f)
        {
            var newPos = self.transform.position;
            var newRot = self.transform.rotation;

            if (conditions.getState() == 0)
            {
                newPos = new Vector3(55.68899917602539f, 0.5947837829589844f, 5.857000350952148f);
                newRot = new Quaternion(-0.289848655462265f, -0.2898487448692322f, 0.6449711322784424f, 0.6449711322784424f);
     
            }
            else if (conditions.getState() == 1)
            {
                newPos = new Vector3(68.82550048828125f, 0.6318011283874512f, -2.09051513671875f);
                newRot = new Quaternion(0.4650202691555023f, 0.6273427605628967f, -0.5198827385902405f, 0.34629344940185549f);
            }
            else
            {
                newPos = new Vector3(57.269493103027347f, 0.4528012275695801f, 9.974485397338868f);
                newRot = new Quaternion(-0.6630071401596069f, -0.4478180706501007f, -0.3366601765155792f, 0.4965285062789917f);
            }


            nextState = new Teleporting(player, self, newPos, newRot, ending);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
