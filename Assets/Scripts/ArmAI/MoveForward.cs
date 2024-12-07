using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Vector3 target;
    public GameObject mainCam, child;
    public Collider player;
    public EndingTransition transition;
    public TriggerArm trigger;
    public float speed;
    public AudioSource audioSource;
    public AudioClip monsterSound;
    private bool hasPlayedSound = false;

    // Start is called before the first frame update
    void Start()
    {
        //target = new Vector3(targetObj.transform.position.x, mainCam.transform.position.y, targetObj.transform.position.z);
        //transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
       // target = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z+0.2f);
       // transform.LookAt(target);
        transform.Translate(0f, 0f, speed * Time.deltaTime);

        if (!hasPlayedSound && speed > 0f)
        {
            audioSource.PlayOneShot(monsterSound);
            hasPlayedSound = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == player)
        {
            transition.SetEnabled();
            child.SetActive(false);
            this.enabled = false;

        }
    }

    public void SetTarget(Vector3 target)
    {
        //this.target = new Vector3(target.x, mainCam.transform.position.y, target.z);
        this.target = new Vector3 (target.x - 0.15f, target.y, target.z);
        transform.LookAt(target);
    }
}