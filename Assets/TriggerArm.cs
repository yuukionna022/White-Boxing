using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArm : MonoBehaviour
{
    public GameObject monster;
    public Collider player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            monster.SetActive(true);

        }
    }
}
