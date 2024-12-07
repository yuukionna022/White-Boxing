using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject continueMenu;
    private bool startMenuState, continueMenuState, triggerStart, triggerContinue;
    private float slider;
    // Start is called before the first frame update
    void Start()
    {
        startMenuState = true;
        continueMenuState = false;
        triggerStart = false;
        triggerContinue = false;
        slider = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerStart)
        {
            slider += Time.deltaTime;
            if (slider > 3)
            {
                startMenuState = true;
                continueMenuState = false;
                triggerStart = false;
                slider = 0;
            }
        }
        if (triggerContinue)
        {
            slider += Time.deltaTime;
            if (slider > 3)
            {
                startMenuState = false;
                continueMenuState = true;
                triggerContinue = false;
                slider = 0;
            }
        }
        if (startMenuState)
        {
            startMenu.SetActive(true);
            continueMenu.SetActive(false);
        }
        if (continueMenuState)
        {
            startMenu.SetActive(false);
            continueMenu.SetActive(true);
        }
    }
    public void startMenuActive()
    {
        triggerStart = true;
    }
    public void continueMenuActive()
    {
        triggerContinue = true;
    }
}
