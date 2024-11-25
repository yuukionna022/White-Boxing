using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfCollider : MonoBehaviour
{
    public bool conditionFulfilled;
    public int requiredNumber;
    public int bookCount;
    public string tagName;

    // Start is called before the first frame update
    void Start()
    {
        bookCount = 0;
        conditionFulfilled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bookCount == requiredNumber)
        {
            conditionFulfilled = true;
        }
        else
        {
            conditionFulfilled = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            bookCount++;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == tagName)
        {
            bookCount--;
        }
    }
}
