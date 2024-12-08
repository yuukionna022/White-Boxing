using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EndingTransition : MonoBehaviour
{

    public TeleportPlayer teleport;
    public TeleportTransition transition;
    public ToggleMenu toggleMenu;
    public Collider player;
    public string ending;
    private bool enable = false;
    public GameObject raycastL, raycastR;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other == player && enable)
        {
            transition.fadeTransition();
            teleport.teleportPlayer();
            if (ending == "Good")
            {
                toggleMenu.goodEndMenuActive();
            }
            if (ending == "Bad")
            {
                toggleMenu.badEndMenuActive();
            }
            raycastL.GetComponent<XRInteractorLineVisual>().enabled = true;
            raycastR.GetComponent<XRInteractorLineVisual>().enabled = true;
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