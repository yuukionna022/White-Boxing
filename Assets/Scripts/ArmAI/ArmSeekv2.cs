using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSeekv2 : MonoBehaviour
{
    public GameObject player;
    public GameObject arm;
    private int timerToAttack;
    public int timeToAttack;
    private int durationTimer;
    public int attackDuration;
    private bool isAttacking;
    private bool attackInProgress;
    public float armSpeed;

    private Vector3 playerPosition;
    private bool positionLocked;
    // Start is called before the first frame update
    void Start()
    {
        timerToAttack = 0;
        durationTimer = 0;
        isAttacking = false;
        attackInProgress = false;
        positionLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Attacking State
        if (isAttacking)
        {
            //Attack Delay
            timerToAttack += 1;
            if (timerToAttack > timeToAttack)
            {
                attackInProgress = true;
                timerToAttack = 0;
                isAttacking = false;
            }
        }
        if (attackInProgress)
        {
            //Attack Duration
            attackPlayer();
            durationTimer += 1;

            //Finished duration
            if (durationTimer > attackDuration)
            {
                durationTimer = 0;
                attackInProgress = false;
                positionLocked = false;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
       if (collision.gameObject.tag == "Player" || collision.gameObject.layer == 7)
       {
            //Start Seeking
            isAttacking = true;
       }
    }
    private void attackPlayer()
    {
        if (positionLocked == false)
        {
            playerPosition = player.transform.position;
            positionLocked = true;
        }
        arm.transform.position = Vector3.MoveTowards(arm.transform.position, playerPosition, armSpeed * Time.deltaTime);
    }
}
