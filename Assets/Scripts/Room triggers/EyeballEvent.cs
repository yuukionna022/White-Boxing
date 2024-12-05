using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballEvent : MonoBehaviour
{

    private Camera main_cam;
    public GameObject eye;
    private Plane[] frustrum;
    private Collider eyeball;
    private bool seen;
    private float counter;
    public TeleportScript script;
    
    // Start is called before the first frame update
    void Start()
    {
        main_cam = Camera.main;
        eyeball = eye.GetComponent<Collider>();
        frustrum = GeometryUtility.CalculateFrustumPlanes(main_cam);
        seen = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = eyeball.bounds;
        frustrum = GeometryUtility.CalculateFrustumPlanes(main_cam);

        if (GeometryUtility.TestPlanesAABB(frustrum, bounds) && script.getEntered())
        {
            counter += Time.deltaTime;
            //Debug.Log(counter);
        } else
        {
            if (counter > 1.5)
            {
                seen = true;
            }
        }

        if (seen == false)
        {
            eye.SetActive(true);
        }
        else
        {
            eye.SetActive(false);
        }
    }
}
