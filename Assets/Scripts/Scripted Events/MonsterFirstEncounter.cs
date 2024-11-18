using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFirstEncounter : MonoBehaviour
{
    private bool encounterTriggered;
    public Flashlight flashlight;
    public GameObject arm;
    public GameObject path1, path2;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        encounterTriggered = flashlight.FlashlightPickedUp();
        if (encounterTriggered)
        {
            //Start timer then arm starts hunting
            timer += 1* Time.deltaTime;
            if (timer > 500 * Time.deltaTime)
            {
                //start hunting player
                arm.transform.position = Vector3.MoveTowards(arm.transform.position, path1.transform.position, 50f);
            }
        }
    }
}
