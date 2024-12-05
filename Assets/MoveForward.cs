using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Vector3 target;
    public Collider player;
    public EndingTransition transition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        target = player.transform.position;
        transform.LookAt(target);
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
            gameObject.SetActive(false);

        }
    }
}
