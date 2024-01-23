using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] LayerMask layermask;
    RaycastHit hitinfo;
    

    // Update is called once per frame
    void Update()
    {
        Ray ray =new Ray (transform.position, transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 50f, layermask, QueryTriggerInteraction.Ignore))
        {
            print("ray hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        } 
        else
        {
            Debug.Log("hoit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50f, Color.blue);
        }
        
    }
}

