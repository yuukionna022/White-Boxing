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
        if (collision.gameObject.layer == 10)
        {

            //Debug.Log("detect collision");
            if (collision.gameObject.tag == "Highlight")
            {
               // Debug.Log("hit");
                //collision.gameObject. = visibleMaterial;
                collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //wordRenderer.enabled = true;

            }

            if (collision.gameObject.tag == "Book Highlight")
            {
               // Debug.Log("hit book");
                HighlightedBook book = collision.gameObject.GetComponent<HighlightedBook>();
                book.highlight();

            }
        }
        
        if (collision.gameObject.layer == 8 && collision.gameObject.tag == "Book Highlight")
        {
            HighlightedBook book = collision.gameObject.GetComponent<HighlightedBook>();
            book.highlight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
           // Debug.Log("collision gone");
            if (other.gameObject.tag == "Highlight")
            {
               // Debug.Log("hit");
                //collision.gameObject. = visibleMaterial;
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                //wordRenderer.enabled = true;

            }
            if (other.gameObject.tag == "Book Highlight")
            {
              //  Debug.Log("hit book exit");
              //  Debug.Log("hit book");
                HighlightedBook book = other.gameObject.GetComponent<HighlightedBook>();
                book.undoHighlight();
            }
        }
        if (other.gameObject.layer == 8 && other.gameObject.tag == "Book Highlight")
        {
            HighlightedBook book = other.gameObject.GetComponent<HighlightedBook>();
            book.undoHighlight();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("detect collision 2");
    //    if (collision.gameObject.tag == "Highlight" || collision.gameObject.layer == 10)
    //    {
    //        Debug.Log("hit 2");
    //        //collision.gameObject. = visibleMaterial;

    //    }
    //}
}
