using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRoom : MonoBehaviour
{
    
    public void teleportRoom()
    {
        transform.position = new Vector3(71.57949829101563f, 3.5617833137512209f, -2.6321864128112795f);
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void teleportSecondTime()
    {
        transform.position = new Vector3(101.77999877929688f, 3.539999485015869f, 3.4600000381469728f);
    }

  
}
