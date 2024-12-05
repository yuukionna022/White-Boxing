using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwo : MonoBehaviour
{
    public ShelfCollider red, green, blue, purple, grey;
    public PuzzleConditions conditions;
    public AudioSource audioSource;
    public AudioClip unlockSound;
    private bool playedSound;
    
    // Start is called before the first frame update
    void Start()
    {
        playedSound = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (green.GetFulfilled() && blue.GetFulfilled() && purple.GetFulfilled())
        {
            conditions.setPuzzleTwo(true);

            if(!playedSound){
                audioSource.PlayOneShot(unlockSound);
                playedSound = true;
            }
            
            //Debug.Log(red.GetFulfilled() && green.GetFulfilled() && blue.GetFulfilled() && purple.GetFulfilled() && grey.GetFulfilled());
            //Debug.Log(conditions.getPuzzleTwo());
        }
    }
}
