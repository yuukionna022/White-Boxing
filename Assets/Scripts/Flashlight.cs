using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Material lens;
    private Light _light;
    private AudioSource _audioSource;
    public bool hasPickedUp;

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
        hasPickedUp = false;
    }
    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;

        hasPickedUp = true;
    }

    public void LighOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        
    }
    public bool FlashlightPickedUp()
    {
        return hasPickedUp;
    }

}
