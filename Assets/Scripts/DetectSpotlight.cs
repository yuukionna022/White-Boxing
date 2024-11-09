using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpotlight : MonoBehaviour
{
    public GameObject itself;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collision collision)
    {
        Debug.Log("detect collision");
        if (collision.gameObject.tag == "Highlight" || collision.gameObject.layer == 10)
        {
            Debug.Log("hit");
            //collision.gameObject. = visibleMaterial;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("detect collision 2");
        if (collision.gameObject.tag == "Highlight" || collision.gameObject.layer == 10)
        {
            Debug.Log("hit 2");
            //collision.gameObject. = visibleMaterial;

        }
    }
}
