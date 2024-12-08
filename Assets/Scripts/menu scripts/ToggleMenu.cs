using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject continueMenu;
    public GameObject goodEndMenu, badEndMenu;
    private bool startMenuState, continueMenuState, goodEndMenuState, badEndMenuState, triggerStart, triggerContinue, triggerGoodEnd, triggerBadEnd;
    private float slider;
    // Start is called before the first frame update
    void Start()
    {
        startMenuState = true;
        continueMenuState = false;
        goodEndMenuState = false;
        badEndMenuState = false;
        triggerStart = false;
        triggerContinue = false;
        triggerGoodEnd = false;
        triggerBadEnd = false;
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
                goodEndMenuState = false;
                badEndMenuState = false;
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
                goodEndMenuState = false;
                badEndMenuState = false;
                triggerContinue = false;
                slider = 0;
            }
        }
        if (triggerGoodEnd)
        {
            slider += Time.deltaTime;
            if (slider > 1)
            {
                startMenuState = false;
                continueMenuState = false;
                goodEndMenuState = true;
                badEndMenuState = false;
                triggerGoodEnd = false;
                slider = 0;
            }
        }
        if (triggerBadEnd)
        {
            slider += Time.deltaTime;
            if (slider > 1)
            {
                startMenuState = false;
                continueMenuState = false;
                goodEndMenuState = false;
                badEndMenuState = true;
                triggerBadEnd = false;
                slider = 0;
            }
        }
        if (startMenuState)
        {
            startMenu.SetActive(true);
            continueMenu.SetActive(false);
            goodEndMenu.SetActive(false);
            badEndMenu.SetActive(false);
        }
        if (continueMenuState)
        {
            startMenu.SetActive(false);
            continueMenu.SetActive(true);
            goodEndMenu.SetActive(false);
            badEndMenu.SetActive(false);
        }
        if (goodEndMenuState)
        {
            startMenu.SetActive(false);
            continueMenu.SetActive(false);
            goodEndMenu.SetActive(true);
            badEndMenu.SetActive(false);
        }
        if (badEndMenuState)
        {
            startMenu.SetActive(false);
            continueMenu.SetActive(false);
            goodEndMenu.SetActive(false);
            badEndMenu.SetActive(true);
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
    public void goodEndMenuActive()
    {
        triggerGoodEnd = true;
    }
    public void badEndMenuActive()
    {
        triggerBadEnd = true;
    }
}
