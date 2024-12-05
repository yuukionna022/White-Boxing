using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTransition : MonoBehaviour
{

    public TeleportPlayer teleport;
    public TeleportTransition transition;
    public Collider player;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            transition.fadeTransition();
            teleport.teleportPlayer();

        }
    }
}