using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectStateScript
{
    public enum STATE
    {
        GRABBABLE, GRABBED, DROPPED, DEACTIVE
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    public XRGrabInteractable interactable;
    protected ObjectStateScript nextState;
    public bool grabbed, isGrabbed;
    protected bool drop;
    protected GameObject player;
    protected GameObject self;


    public ObjectStateScript(XRGrabInteractable grabbable, GameObject player, GameObject self)
    {
        interactable = grabbable;
        this.player = player;
        this.self = self;
        grabbed = false;
        isGrabbed = false;
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

    protected virtual void OnGrabbed(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            grabbed = true;
            // Debug.Log(grabbed);
        }
    }

    protected virtual void OnReleased(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            grabbed = false;
            //  Debug.Log(grabbed);
        }
    }

    public bool Dropped()
    {
        return drop;
    }

    public void Drop()
    {
        drop = true;
    }

    public bool Grabbed()
    {
        return grabbed;
    }

}

public class Grabbable : ObjectStateScript
{
    public Grabbable(XRGrabInteractable grabbable, GameObject player, GameObject self) : base(grabbable, player, self)
    {
        name = STATE.GRABBABLE;
        interactable.enabled = true;
        grabbed = false;
    }

    public override void Enter()
    {
        base.Enter();
    }

    

    public override void Update()
    {
       // UnityEngine.Debug.Log("grabbable");

        if (grabbed && interactable.isSelected)
        {
            nextState = new Grabbed(interactable, player, self);
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
    public Grabbed(XRGrabInteractable grabbable, GameObject player, GameObject self) : base(grabbable, player, self)
    {
        name = STATE.GRABBED;
        grabbed = true;
        isGrabbed = true;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
       // UnityEngine.Debug.Log("grabbed");

        if (drop)
        {
            nextState = new Deactive(interactable, player, self);
            stage = EVENT.EXIT;
        }
        else if (!grabbed)
        {
            nextState = new Dropped(interactable, player, self);
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
    
    
    public Dropped(XRGrabInteractable grabbable, GameObject player, GameObject self) : base(grabbable, player, self)
    {
        name = STATE.DROPPED;
        interactable.enabled = false;
        grabbed = false;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
       // UnityEngine.Debug.Log("dropped");
       // interactable.enabled = false;
        if ((self.transform.position - player.transform.position).magnitude < 2.5f)
        {
            nextState = new Grabbable(interactable, player, self);
            stage = EVENT.EXIT;
        }


    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Deactive : ObjectStateScript
{


    public Deactive(XRGrabInteractable grabbable, GameObject player, GameObject self) : base(grabbable, player, self)
    {
        name = STATE.DEACTIVE;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
        self.SetActive(false);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
