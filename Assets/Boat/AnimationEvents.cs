using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public AudioSource paddleAudio;
    public AudioClip paddleClip;
    void Start()
    {
        
    }

    public void TriggerEvents()
    {
        paddleAudio.PlayOneShot(paddleClip);
    }
}
