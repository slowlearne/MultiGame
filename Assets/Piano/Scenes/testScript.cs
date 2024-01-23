using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testScript : MonoBehaviour,IPointerDownHandler
{
    public AudioSource source;
    public AudioClip clip;

    public void OnPointerDown(PointerEventData eventData)
    {
        playSound();
    }

    // Start is called before the first frame update
    void playSound()
    {
        source.PlayOneShot(clip);
    }
    void Start()
    {
        
    }


   
}
