using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
    public enum STATE
    {
        IDLE, PURSUE, SCREAM, ATTACK
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;

    float visDist = 8.0f;
  //  float visAngle = 30.0f;
    float attackDist = 1.5f;

    public State(GameObject npc, NavMeshAgent agent, Animator anim, Transform player)
    {
        this.npc = npc;
        this.agent = agent;
        this.anim = anim;
        this.player = player;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.ENTER; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
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

    public bool CanSeePlayer()
    {

        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);

        if (direction.magnitude < visDist) // && angle < visAngle)
        {
            UnityEngine.Debug.Log("see"); 

            return true;
        }

        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.position - npc.transform.position;
        if (direction.magnitude < attackDist)
        {
            UnityEngine.Debug.Log("can attack");
            return true;
        }
        return false;
    }

}
    
public class Idle : State
{
    public Idle(GameObject npc, NavMeshAgent agent, Animator anim, Transform player) 
        : base(npc, agent, anim, player) 
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        UnityEngine.Debug.Log("idle");

        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}


public class Pursue:State
{
    public Pursue(GameObject npc, NavMeshAgent agent, Animator anim, Transform player)
        : base(npc, agent, anim, player)
    {
        name = STATE.PURSUE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        //move towards player
        agent.SetDestination(player.position);
        UnityEngine.Debug.Log("chase");
        if (CanAttackPlayer())
        {
            nextState = new Attack(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        else if (!CanSeePlayer()) 
        {
            nextState = new Idle(npc, agent, anim, player); 
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}


public class Scream : State
{
    public Scream(GameObject npc, NavMeshAgent agent, Animator anim, Transform player)
        : base(npc, agent, anim, player)
    {
        name = STATE.SCREAM;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            //nextState = new Scream(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}

public class Attack : State
{

    //protected float height;
    protected float orig_height;
    [SerializeField] float fly = 5.0f;
    [SerializeField] float range = 15.0f;
    protected Vector3 pos;

    public Attack(GameObject npc, NavMeshAgent agent, Animator anim, Transform player)
        : base(npc, agent, anim, player)
    {
        name = STATE.ATTACK;
        orig_height = npc.transform.position.y;
        pos = npc.transform.position;
    }

    public override void Enter()
    {
        base.Enter();
        agent.isStopped = true;
    }

    public override void Update()
    {

        UnityEngine.Debug.Log("fly");
        float newYpos = Mathf.Sin(Time.time * fly) * range + pos.y;
        npc.transform.position = new Vector3(npc.transform.position.x, newYpos, npc.transform.position.z);
        UnityEngine.Debug.Log(newYpos);
        UnityEngine.Debug.Log(npc.transform.position);

        if (!CanAttackPlayer())
        {
            npc.transform.position = new Vector3(npc.transform.position.x, orig_height, npc.transform.position.z);
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
        agent.isStopped = false;
    }

}
