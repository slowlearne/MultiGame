using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
    public ParticleSystem particle;

    public void OnButtonClick()
    {
        particle.Play();
        // Add your custom button click behavior here
    }
}
