using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFirstEncounter : MonoBehaviour
{
    public bool encounterTriggered;
    public Flashlight flashlight;
    private int timer;

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
            timer += 1;
            if (timer > 200)
            {
                //start hunting player

            }
        }
    }
}
