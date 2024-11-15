using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSeekingState : MonoBehaviour
{
    private Ray ray;
    //public float rot1, rot2, rot3;
    // Start is called before the first frame update
    public int layerToHit;
    private RaycastHit hitInfo;

    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
       // RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1f))
        {
            if (hitInfo.collider.gameObject.layer == layerToHit || hitInfo.collider.gameObject.tag == "Player")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, -1, 0)) * 1f, Color.green);
                Debug.Log("player hit");
            }
            else
            {
                Debug.Log("player not hit");
                Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, -1, 0)) * 1f, Color.red);
            }


            Debug.Log("Layer: " + hitInfo.collider.gameObject.layer);
            Debug.Log("Tag: " + hitInfo.collider.tag);

            //Some arm seeking actions
        }
        //else
        //{
        //    Debug.Log("player not hit");
        //    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, -1, 0)) * 100f, Color.red);
        //}
    }
}

