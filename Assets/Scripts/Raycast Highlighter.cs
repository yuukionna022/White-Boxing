using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHighlighter : MonoBehaviour
{
    public float distanceToSee;
    public string ObjectName;
    private Color highlightColor;
    Material originalMaterial, tempMaterial;
    Renderer rend = null;
    // Start is called before the first frame update
    void Start()
    {
        highlightColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Renderer currRend;
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee))
        {
            currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();

            if (currRend == rend)
                return;

            if (currRend && currRend != rend)
            {
                if (rend)
                {
                    rend.sharedMaterial = originalMaterial;
                }

            }

            if (currRend)
                rend = currRend;
            else
                return;

            originalMaterial = rend.sharedMaterial;

            tempMaterial = new Material(originalMaterial);
            rend.material = tempMaterial;
            rend.material.color = highlightColor;
        }
        else
        {
            if (rend)
            {
                rend.sharedMaterial = originalMaterial;
                rend = null;
            }
        }
    }
}
