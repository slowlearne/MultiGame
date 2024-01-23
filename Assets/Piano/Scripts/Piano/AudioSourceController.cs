using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AudioSourceController : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip audioclip;
    public void playSound()
    {
        
        audiosource.PlayOneShot(audioclip);
    }

    
}
