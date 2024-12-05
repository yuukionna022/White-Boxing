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

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
        hasPickedUp = false;
        state = new Drop(player, self, playerCol);
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

    }

    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;
        hasPickedUp = true;
        var main = glowEmitter.main;
        main.maxParticles = 0;
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
        var main = glowEmitter.main;
        main.maxParticles = 4;
    }
    public bool FlashlightPickedUp()
    {
        return hasPickedUp;
    }
}
