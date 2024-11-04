using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpotlight : MonoBehaviour
{
    public Material visibleMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collision collision)
    {
        if (collision.gameObject.tag == "Highlight")
        {
            Debug.Log("hit");
            print("hit");
            //collision.gameObject. = visibleMaterial;

        }
    }
}
