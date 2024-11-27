using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeball : MonoBehaviour
{
    private GameObject player;
    private float max, min, fixedx, fixedz;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Collider");
        max = 290f;
        min = 249f;
        fixedx = transform.localEulerAngles.x;
        fixedz = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && (player.transform.position - transform.position).magnitude < 9f)
        {
            transform.LookAt(player.transform.position);
        }

        Debug.Log(transform.localEulerAngles);

        if (transform.localEulerAngles.y < min)
        {
            transform.localEulerAngles = new Vector3(fixedx, min, fixedz);
        }
        else if (transform.localEulerAngles.y > max)
        {
            transform.localEulerAngles = new Vector3(fixedx, max, fixedz);
        }

        if (transform.localEulerAngles.x < fixedx || transform.localEulerAngles.x > fixedx)
        {
            transform.localEulerAngles = new Vector3(fixedx, transform.localEulerAngles.y, fixedz);
        }
       


    }
}
