using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light myLight;
    public GameObject flashlight;
    public float lightIntensity;
    public float randOn;
    public float randOff;
    private float timer;
    private float random;
    private bool isOff;
    private bool flashlightPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        isOff = false;
        flashlightPickedUp = false;
        random = 50;
        timer = 0;
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        flashlightPickedUp = flashlight.GetComponent<Flashlight>().FlashlightPickedUp();

        if (flashlightPickedUp == false) {
            if (timer > random && isOff == false)
            {
                //Random length of time for light to be off
                random = Random.Range(2, randOff);
                myLight.intensity = 0;
                timer = 0;
                isOff = true;
                //Debug.Log("Switch off");
            }
            if (timer > random && isOff == true)
            {
                //Random length of time for light to be on
                random = Random.Range(2, randOn);
                myLight.intensity = lightIntensity;
                timer = 0;
                isOff = false;
                //Debug.Log("Switch on");
            }
            timer += 1;
            //Debug.Log(timer);
        }
        else
        {
            myLight.intensity = 0;
        }
    }
}
