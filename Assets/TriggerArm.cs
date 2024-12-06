using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArm : MonoBehaviour
{
    public GameObject monster, mainCam;
    public Collider player;
    private Vector3 position;
    private MoveForward moveForward;


    private void Start()
    {
        moveForward = monster.GetComponent<MoveForward>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            
            position = mainCam.transform.position;
            monster.SetActive(true);
            moveForward.SetTarget(position);
            this.gameObject.SetActive(false);
        }
    }
}
