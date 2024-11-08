using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public GameObject book;
    public GameObject player;
    private int defaultLayer;
    private int interactLayer;

    // Start is called before the first frame update
    void Start()
    {
        defaultLayer = LayerMask.NameToLayer("Default");
        interactLayer = LayerMask.NameToLayer("interactable");
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - book.transform.position).magnitude > 2.0f)
        {
            book.layer = defaultLayer;
        } else
        {
            book.layer = interactLayer;
        }
        
        Debug.Log(book.layer);
    }
}
