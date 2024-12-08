using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwo : MonoBehaviour
{
    public ShelfCollider red, green, blue, purple, grey;
    public PuzzleConditions conditions;
    public AudioSource audioSource;
    public AudioClip unlockSound;
    public AudioClip confirmSound;
    private bool playedSound;
    private bool playedSoundGreen;
    private bool playedSoundBlue;
    private bool playedSoundPurple;
    
    // Start is called before the first frame update
    void Start()
    {
        playedSound = false;
        playedSoundGreen = false;
        playedSoundBlue = false;
        playedSoundPurple = false;
        
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

        if (green.GetFulfilled())
        {
            if(!playedSoundGreen){
                audioSource.PlayOneShot(confirmSound);
                playedSoundGreen = true;
            }
        }

        if (blue.GetFulfilled())
        {
            if(!playedSoundBlue){
                audioSource.PlayOneShot(confirmSound);
                playedSoundBlue = true;
            }
        }

        if (purple.GetFulfilled())
        {
            if(!playedSoundPurple){
                audioSource.PlayOneShot(confirmSound);
                playedSoundPurple = true;
            }
        }
        
    }
}
