using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSeekv2 : MonoBehaviour
{
    public GameObject player;
    public GameObject arm;
    private int timerToAttack;
    public static int timeToAttack = 50;
    private int durationTimer;
    public static int attackDuration = 10;
    private bool isAttacking;
    private bool attackInProgress;

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

            if (durationTimer > attackDuration)
            {
                durationTimer = 0;
                attackInProgress = false;
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
        arm.transform.position = Vector3.MoveTowards(arm.transform.position, playerPosition, 1);
    }
}
