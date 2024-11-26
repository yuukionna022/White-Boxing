using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightArrow : MonoBehaviour
{
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlight()
    {
        //Debug.Log("highlighted");
        rend.enabled = true;
    }

    public void undoHighlight()
    {
        //Debug.Log("not highlighted");
        rend.enabled = false;
    }
}
