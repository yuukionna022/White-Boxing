using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectStateScript
{
    public enum STATE
    {
        GRABBABLE, GRABBED, DROPPED
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected XRGrabInteractable interactable;
    protected ObjectStateScript nextState;
    protected bool grabbed;
    protected bool drop;

    public ObjectStateScript(XRGrabInteractable grabbable)
    {
        interactable = grabbable;
        grabbed = false;
        drop = false;
        interactable.selectEntered.AddListener(OnGrabbed);
        interactable.selectExited.AddListener(OnReleased);
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.ENTER; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public ObjectStateScript Process()
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
    }

    protected void OnReleased(SelectExitEventArgs args)
    {
        grabbed = false;
    }

    protected bool Dropped()
    {
        return drop;
    }

}

public class Grabbable : ObjectStateScript
{
    public Grabbable(XRGrabInteractable grabbable) : base(grabbable)
    {
        name = STATE.GRABBABLE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    

    public override void Update()
    {
        UnityEngine.Debug.Log("grabbable");

        if (grabbed)
        {
            nextState = new Grabbed(interactable);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Grabbed : ObjectStateScript
{
    public Grabbed(XRGrabInteractable grabbable) : base(grabbable)
    {
        name = STATE.GRABBED;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
        UnityEngine.Debug.Log("grabbed");

        if (drop)
        {
            nextState = new Dropped(interactable);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Dropped : ObjectStateScript
{
    
    
    public Dropped(XRGrabInteractable grabbable) : base(grabbable)
    {
        name = STATE.DROPPED;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
        UnityEngine.Debug.Log("dropped");
        interactable.enabled = false;
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
