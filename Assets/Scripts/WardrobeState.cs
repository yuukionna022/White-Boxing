using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WardrobeState 
{
    public enum STATE
    {
        OPEN, HIDING
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject player;
    protected Collider wardrobeCollider, playerCollider;
    protected WardrobeState nextState;
    protected bool entered;

    public WardrobeState(GameObject player, Collider wardrobe)
    {
        this.player = player;
        wardrobeCollider = wardrobe;
        playerCollider = player.GetComponent<Collider>();
        entered = false;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.ENTER; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public WardrobeState Process()
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

    public void SetEntered(bool isEntered)
    {
        entered = isEntered;
    }
}

public class Open : WardrobeState
{
    public Open(GameObject player, Collider wardrobe) : base(player, wardrobe)
    {
        name = STATE.OPEN;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
        
        if (entered)
        {
            nextState = new Hiding(player, wardrobeCollider);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

public class Hiding : WardrobeState
{
    public Hiding(GameObject player, Collider wardrobe) : base(player, wardrobe)
    {
        name = STATE.HIDING;
        entered = true;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Update()
    {
        
        if (!entered)
        {
            nextState = new Open(player, wardrobeCollider);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
