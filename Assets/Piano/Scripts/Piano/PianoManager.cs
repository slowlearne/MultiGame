using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{
    public   bool letPointerEnter;
    public static PianoManager instance;
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        print("update" + letPointerEnter);

        if (Input.GetMouseButtonUp(0))
        {
            letPointerEnter = false;
        }
    }

}
