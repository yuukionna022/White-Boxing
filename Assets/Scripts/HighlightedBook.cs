using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightedBook : MonoBehaviour
{
    public GameObject self;
    Renderer rend;
    Material ogMaterial;
    public Material highlightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rend = self.GetComponent<Renderer>();
        ogMaterial = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlight()
    {
        Debug.Log("highlighted");
        rend.material = highlightMaterial;
    } 

    public void undoHighlight()
    {
        Debug.Log("not highlighted");
        rend.material = ogMaterial;
    }
}
