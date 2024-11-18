using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject player;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).magnitude < 4.0f)
        {
            grabbed = true;
        } else
        {
            grabbed = false;
        }


    }



    public bool key_grabbed()
    {
        return grabbed;
    }
}
