using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Material lens;
    public ParticleSystem glowEmitter;
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
        glowEmitter.maxParticles = 0;
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        glowEmitter.maxParticles = 4;
    }
    public bool FlashlightPickedUp()
    {
        return hasPickedUp;
    }
}
