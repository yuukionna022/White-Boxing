using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTransition : MonoBehaviour
{

    public TeleportPlayer teleport;
    public TeleportTransition transition;
    public Collider player;
    private bool enable = false;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other == player && enable)
        {
            transition.fadeTransition();
            teleport.teleportPlayer();

        }
    }

    public bool Enabled()
    {
        return enable;
    }

    public void SetEnabled()
    {
        enable = true;
    }
}