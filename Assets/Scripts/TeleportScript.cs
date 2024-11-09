using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform teleportationTarget;
    public GameObject player;
    public PuzzleConditions conditions;
    public bool teleporting = false;


    void OnTriggerEnter(Collider Col)
    {
        Debug.Log("entered");
        if (conditions.getPuzzleOne())
        {
            teleporting = true;
            player.transform.position = teleportationTarget.position;
            player.transform.Rotate(0.0f, 180.0f, 0.0f);
                   
        }
    }

    public bool getTeleporting()
    {
        return teleporting;
    }


}
