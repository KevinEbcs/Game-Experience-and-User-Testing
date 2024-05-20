using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthSound : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip sfx;
    
    
    public void playAudio()
    {
        Source.clip = sfx;
        Source.Play();
    }
}
