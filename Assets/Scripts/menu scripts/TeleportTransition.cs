using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportTransition : MonoBehaviour
{
    public Image panel;
    public float transitionTime;
    public bool triggerTransition;
    private float slider;
    private bool unfade;
    public bool isWhite;
    // Start is called before the first frame update
    void Start()
    {
        triggerTransition = false;
        unfade = false;
        slider = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("slider = " + slider);
        //Debug.Log("alpha = " + panel.color.a);
        if (triggerTransition == true)
        {
            if (unfade == false)
            {
                slider += Time.deltaTime / transitionTime;
                if (isWhite)
                {
                    panel.color = new UnityEngine.Color(255, 255, 255, slider);
                }
                else {
                    panel.color = new UnityEngine.Color(panel.color.r, panel.color.g, panel.color.b, slider);
                }
            }
            //Transition unfades from black (with a delay of when 1.0f < panel.color.a < 2.0f)
            if (panel.color.a >= 2.0f)
            {
                unfade = true;
            }
            if (unfade == true)
            {
                slider -= Time.deltaTime / transitionTime;
                if (isWhite)
                {
                    panel.color = new UnityEngine.Color(255, 255, 255, slider);
                }
                else
                {
                    panel.color = new UnityEngine.Color(panel.color.r, panel.color.g, panel.color.b, slider);
                }
            }
            //Transition Finishes
            if (panel.color.a <= 0f)
            {
                unfade = false;
                slider = 0;
                triggerTransition = false;
            }
        }
    }

    public void fadeTransition()
    {
        triggerTransition = true;
    }
}
