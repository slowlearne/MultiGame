using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    public GameObject planePrefab;  // Reference to the plane prefab
    public Transform character;     // Reference to the character's transform
    private Transform lastAddedPlane;
    private Transform currentPlane;
    bool isPlaneAdded;
    GameObject newPlane;
    void Start()
    {
        GameObject initialPlane = Instantiate(planePrefab, new Vector3(0,0,140f), Quaternion.identity, gameObject.transform);
        lastAddedPlane = initialPlane.transform;
    }


    void Update()
    {
        // Check the character's position to add or remove planes
        if (character.position.z > lastAddedPlane.position.z + 220f)
        {
            RemoveOldestPlane();
        }

        if (character.position.z > lastAddedPlane.position.z - 120f)
        {
            if (!isPlaneAdded)
            {
                AddPlane();
            }

        }
    }

    void AddPlane()
    {
        print("plane added");
        isPlaneAdded = true;
        // Instantiate a new plane and position it at the end of the last added plane
         newPlane = Instantiate(planePrefab, lastAddedPlane.transform.position + new Vector3(0, 0, 300.5f), Quaternion.identity, gameObject.transform);
        
    }

    void RemoveOldestPlane()
    {
        print("plane removed");
        // Find and remove the oldest plane

        lastAddedPlane = newPlane.transform;
        if (gameObject.transform.childCount > 0)
        {
            Transform planeToDestroy = gameObject.transform.GetChild(0);
            Destroy(planeToDestroy.gameObject);
        }
        isPlaneAdded = false;
    }
}


