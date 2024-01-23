using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DentedPixel;

public class LeanTweenScript : MonoBehaviour
{

    void Start()
    {
        LeanTween.moveY(gameObject, -200, 3f).setEaseOutBounce();
    }
}
