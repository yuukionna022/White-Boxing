using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Vector3 target;
    public GameObject mainCam;
    public Collider player;
    public EndingTransition transition;
    public TriggerArm trigger;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //target = new Vector3(targetObj.transform.position.x, mainCam.transform.position.y, targetObj.transform.position.z);
        //transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            transition.SetEnabled();
            //gameObject.SetActive(false);
            this.enabled = false;

        }
    }

    public void SetTarget(Vector3 target)
    {
        //this.target = new Vector3(target.x, mainCam.transform.position.y, target.z);
        this.target = new Vector3 (target.x-0.02f, target.y, target.z);
        transform.LookAt(target);
    }
}