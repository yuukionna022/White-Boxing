using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpotlight : MonoBehaviour
{
    Material originalMaterial, tempMaterial;


    // Start is called before the first frame update
    void Start()
    {
        //wordRenderer = words.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject other = collision.gameObject;
        if (other.layer == 10)
        {

            //Debug.Log("detect collision");
            if (other.tag == "Highlight")
            {
               // Debug.Log("hit");
                //collision.gameObject. = visibleMaterial;
               other.GetComponent<MeshRenderer>().enabled = true;
                //wordRenderer.enabled = true;

            }

            if (other.tag == "Book Highlight")
            {
                //Debug.Log("hit book");
                HighlightedBook book = other.GetComponent<HighlightedBook>();
                book.highlight();

            } 

            if(other.tag == "Arrow")
            {
                //Debug.Log("hit arrow");
                HighlightArrow arrow = other.GetComponent<HighlightArrow>();
                arrow.highlight();
            }
        }
        if (other.layer == 8)
        {
            if (other.tag == "Book Highlight")
            {
                HighlightedBook book = other.GetComponent<HighlightedBook>();
                book.highlight();
            }

            if (other.tag == "Key Highlight")
            {
                other.GetComponent<MeshRenderer>().enabled = true;
            }

            if (other.name == "Glow Emitter")
            {
                var emitter = other.GetComponent<ParticleSystem>();
                var main = emitter.main;
                main.maxParticles = 4;
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        GameObject other = col.gameObject;
        if (other.layer == 10)
        {
            // Debug.Log("collision gone");
            if (other.tag == "Highlight")
            {
                // Debug.Log("hit");
                //collision.gameObject. = visibleMaterial;
                other.GetComponent<MeshRenderer>().enabled = false;
                //wordRenderer.enabled = true;

            }
            if (other.gameObject.tag == "Book Highlight")
            {
                //  Debug.Log("hit book exit");
                //  Debug.Log("hit book");
                HighlightedBook book = other.GetComponent<HighlightedBook>();
                book.undoHighlight();
            }

            if (other.tag == "Arrow")
            {
                //  Debug.Log("hit book exit");
                //  Debug.Log("hit book");
                HighlightArrow arrow = other.GetComponent<HighlightArrow>();
                arrow.undoHighlight();
            }
        }
        if (other.layer == 8)
        {
            if (other.tag == "Book Highlight")
            {
                HighlightedBook book = other.GetComponent<HighlightedBook>();
                book.undoHighlight();
            }

            if (other.tag == "Key Highlight")
            {
                other.GetComponent<MeshRenderer>().enabled = false;
            }

            if (other.name == "Glow Emitter")
            {
                var emitter = other.GetComponent<ParticleSystem>();
                var main = emitter.main;
                main.maxParticles = 0;
            }
        }
                
    }
}
