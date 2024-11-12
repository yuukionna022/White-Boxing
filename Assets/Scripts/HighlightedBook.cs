using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightedBook : MonoBehaviour
{
    public GameObject self;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = self.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlight()
    {
        Debug.Log("highlighted");
    } 

    public void undoHighlight()
    {
        Debug.Log("not highlighted");
    }
}
