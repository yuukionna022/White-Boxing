using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Material lens;
    public ParticleSystem glowEmitter;
    private Light _light;
    private AudioSource _audioSource;
    public bool hasPickedUp;
    private FlashlightFSM state;
    public GameObject player, self;
    public ending end;
    public Collider playerCol;

    private bool batteryOn;
    public float batteryLife;
    public int flickerProbability;
    private bool isFlickering;
    private bool isChecking;
    private bool triggerOnce;
    private float timeBeforeNextCheck;
    private float flickerTime;
    private int gen;
    private float tempLightIntensity;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
        hasPickedUp = false;
        state = new Drop(player, self, playerCol);
        batteryOn = false;


        isFlickering = false;
        isChecking = true;
        triggerOnce = false;
        timeBeforeNextCheck = 0;
        flickerTime = 0.1f;
        gen = 0;
        tempLightIntensity = 0;
    }

    void Update()
    {
        state = state.Process();
        if (end.Drop())
        {
            //Debug.Log("drop flashlight");
            self.GetComponent<XRGrabInteractable>().enabled = false;
            self.SetActive(false);
        }

        if (batteryOn)
        {
            //Run down timer for battery life
            //Debug.Log("light intensity: " + _light.intensity);
            _light.intensity -= Time.deltaTime / batteryLife;
        }
        if (_light.intensity < 0.7 && _light.intensity > 0.3)
        {
            //Minor light flicker
            if (isChecking)
            {
                if (_light.intensity < 0.3)
                {
                    //More intense light flicker
                    timeBeforeNextCheck = Random.Range(1, 1);
                }
                else
                {
                    timeBeforeNextCheck = Random.Range(1, 3);
                }
                isChecking = false;
                gen = Random.Range(1, 100);
                if (gen <= flickerProbability && isFlickering == false)
                {
                    isFlickering = true;
                }
            }
            if (!isChecking && !isFlickering)
            {
                //Light will be on
                timeBeforeNextCheck -= Time.deltaTime;
                if (timeBeforeNextCheck < 0)
                {
                    isChecking = true;
                }
            }
            if (isFlickering)
            {
                flickerTime -= Time.deltaTime;
                if (!triggerOnce)
                {
                    tempLightIntensity = _light.intensity;
                    _light.intensity = 0;
                    triggerOnce = true;
                }
                if (flickerTime < 0)
                {
                    flickerTime = 0.1f;
                    isFlickering = false;
                    isChecking = true;
                    triggerOnce = false;
                    _light.intensity = tempLightIntensity;
                }
            }
        }

        if(_light.intensity <= 0)
        {
            //fade then teleport player to end room
        }

    }

    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;
        hasPickedUp = true;
        var main = glowEmitter.main;
        main.maxParticles = 0;
        batteryOn = true;
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        var main = glowEmitter.main;
        main.maxParticles = 4;
        batteryOn = false;
    }
    public bool FlashlightPickedUp()
    {
        return hasPickedUp;
    }
}
