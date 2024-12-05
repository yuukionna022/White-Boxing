using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeepFlashlight : MonoBehaviour
{

    public PuzzleConditions conditions;
    public GameObject player;
    private bool grabbed = false;
    public ending ending;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnGrabbed);
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnReleased);
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabbed && (transform.position - player.transform.position).magnitude > 3f)
        {
            if (conditions.getState() == 0)
            {
                transform.position = new Vector3(55.68899917602539f, 0.5947837829589844f, 5.857000350952148f);
                transform.rotation = new Quaternion(-0.289848655462265f, -0.2898487448692322f, 0.6449711322784424f, 0.6449711322784424f);
            }else if (conditions.getState() == 1)
            {
                transform.position = new Vector3(68.82550048828125f, 0.6318011283874512f, -2.09051513671875f);
                transform.rotation = new Quaternion(0.4650202691555023f, 0.6273427605628967f, -0.5198827385902405f, 0.34629344940185549f);
            } else
            {
                transform.position = new Vector3(57.269493103027347f, 0.4528012275695801f, 9.974485397338868f);
                transform.rotation = new Quaternion(-0.6630071401596069f, -0.4478180706501007f, -0.3366601765155792f, 0.4965285062789917f);
            }
        }

        if (ending.Drop())
        {
            gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            gameObject.SetActive(false);
        }
    }

    protected void OnGrabbed(SelectEnterEventArgs args)
    {
        grabbed = true;
        //Debug.Log(grabbed);
    }

    protected void OnReleased(SelectExitEventArgs args)
    {
        grabbed = false;
        //Debug.Log(grabbed);
    }
}
