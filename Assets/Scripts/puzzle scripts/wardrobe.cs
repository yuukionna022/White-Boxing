using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class wardrobe : MonoBehaviour
{

    public GameObject player;
    public Collider self, playerCollider;
    private WardrobeState state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = new Open(player, self);
        playerCollider = player.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        state = state.Process(); 
    }

    protected void OnTriggerEnter(Collider other)
    {

        if (other == playerCollider)
        {
           // UnityEngine.Debug.Log("player in wardrobe");
            state.SetEntered(true);
        }
    }

    protected void OnTriggerExit(Collider other)
    {

        if (other == playerCollider)
        {
           // UnityEngine.Debug.Log("player left wardrobe");
            state.SetEntered(false);
        }
    }
}
