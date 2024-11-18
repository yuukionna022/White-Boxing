using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSeekv2 : MonoBehaviour
{
    public GameObject player;
    public GameObject arm;
    public GameObject wrist;
    public GameObject joint4, joint5, joint6, joint7, joint8;
    private float timerToAttack;
    public int timeToAttack;
    private float durationTimer;
    public int attackDuration;
    private bool isAttacking;
    private bool attackInProgress;
    public float armSpeed;
    private float singleStep;
    public float rotationSpeed;

    private float scanTimer;
    public float scanFrequency;

    private Vector3 playerPosition;
    private bool positionLocked;

    public bool isScanning;
    private int scanMode;

    public float x, y, z;

    private Quaternion joint4rot, joint5rot, joint6rot, joint7rot, joint8rot;
    // Start is called before the first frame update
    void Start()
    {
        timerToAttack = 0;
        durationTimer = 0;
        scanTimer = 0;
        isAttacking = false;
        attackInProgress = false;
        positionLocked = false;
        singleStep = armSpeed * Time.deltaTime;
        isScanning = false;
        scanMode = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Scanning State
        if (isScanning)
        {
            scan();
        }
        //Attacking State
        if (isAttacking)
        {
            //Attack Delay
            timerToAttack += (1 *Time.deltaTime);
            if (timerToAttack > timeToAttack * Time.deltaTime)
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
            durationTimer += (1 * Time.deltaTime);

            //Finished duration
            if (durationTimer > attackDuration * Time.deltaTime)
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
            rotateArm();
        }
        arm.transform.position = Vector3.MoveTowards(arm.transform.position, playerPosition, armSpeed * Time.deltaTime);
    }
    private void rotateArm()
    {
        Vector3 targetDirection = transform.position - player.transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed*singleStep, 0);
        arm.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void grabAnimation()
    {
        if (!isAttacking)
        {
            //save position before attack
            joint4rot = joint4.transform.rotation;
            joint5rot = joint5.transform.rotation;
            joint6rot = joint6.transform.rotation;
            joint7rot = joint7.transform.rotation;
            joint8rot = joint8.transform.rotation;
        }
        else
        {
            //joint4.transform.rotation = 
        }
    }

    private void scan()
    {
        scanTimer += Time.deltaTime;
        //Rotate wrist
        if (scanTimer > scanFrequency * Time.deltaTime)
        {
            switch (scanMode) {
                case 0:
                    wrist.transform.Rotate(x, y, z);
                    scanMode = 1;
                    break;
                case 1:
                    wrist.transform.Rotate(-2*x, y, -2*z);
                    scanMode = 2;
                    break;
                case 2:
                    wrist.transform.Rotate(x, y, z);
                    scanMode = 0;
                    break;
            }
            scanTimer = 0;
        }
    }

    public void scanningSwitch()
    {
        isScanning = !isScanning;
    }
    public void attackingSwitch()
    {
        isAttacking = !isAttacking;
    }
}
