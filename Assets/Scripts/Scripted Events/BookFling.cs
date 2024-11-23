using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFling : MonoBehaviour
{
    public GameObject obj1, obj2, obj3;
    public GameObject flingPath;
    public BookGrabbable condition;
    public bool isFlinging;
    public float flingSpeed;
    public int flingCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        isFlinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (condition.Grabbed())
        {
            isFlinging = true;
        }
        if (isFlinging && flingCount < 10)
        {
            obj1.transform.position = Vector3.MoveTowards(obj1.transform.position, flingPath.transform.position, flingSpeed * Time.deltaTime);
            obj2.transform.position = Vector3.MoveTowards(obj2.transform.position, flingPath.transform.position, flingSpeed * Time.deltaTime);
            obj3.transform.position = Vector3.MoveTowards(obj3.transform.position, flingPath.transform.position, flingSpeed * Time.deltaTime);
            flingCount++;
            if (flingCount > 10) isFlinging = false;
        }
    }
}
