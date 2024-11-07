using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Transform player;
    State currentState;
    //float visDist = 10.0f;
    //float visAngle = 30.0f;
    //float attackDist = 1.0f;


   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentState = new Idle(this.gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
        
    }
}
