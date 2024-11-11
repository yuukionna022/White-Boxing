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
 
        
        Debug.Log("detect collision");
        if (collision.gameObject.tag == "Highlight" || collision.gameObject.layer == 10)
        {
            Debug.Log("hit");
            //collision.gameObject. = visibleMaterial;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = true;
            //wordRenderer.enabled = true;

        } 

        if(collision.gameObject.tag == "Book Highlight")
        {
            Debug.Log("hit book");
            Renderer rend = collision.gameObject.GetComponent<Renderer>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision gone");
        if (other.gameObject.tag == "Highlight" || other.gameObject.layer == 10)
        {
            Debug.Log("hit");
            //collision.gameObject. = visibleMaterial;
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //wordRenderer.enabled = true;

        }
        if (other.gameObject.tag == "Book Highlight")
        {
            Debug.Log("hit book exit");
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
