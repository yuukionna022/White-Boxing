using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class wardrobe : MonoBehaviour
{

    public GameObject player;
    private CapsuleCollider collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = player.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

      
        if (other == collider)
        {
            Debug.Log("player in wardrobe");
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (other == collider)
        {
            Debug.Log("player left wardrobe");
        }
    }

}
