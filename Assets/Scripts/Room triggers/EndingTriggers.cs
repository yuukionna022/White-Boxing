using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTriggers : MonoBehaviour
{
    public GameObject player;
    public GameObject transitionScript, teleportScript, menuScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject col = other.gameObject;
        if (col == player)
        {
            
        }
    }
}
