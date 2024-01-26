using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaneC : MonoBehaviour
{
    public GameObject planePrefab;  // Reference to the plane prefab
    public Transform character;     // Reference to the character's transform
    private Transform lastAddedPlane;
    private Transform currentPlane;
    bool isPlaneAdded;
    GameObject newPlane;
    void Start()
    {
        GameObject initialPlane = Instantiate(planePrefab, new Vector3(0, 0, 92f), Quaternion.Euler(0f, 0f, 0f), gameObject.transform);
        lastAddedPlane = initialPlane.transform;
    }


    void Update()
    {
        // Check the character's position to add or remove planes
        if (character.position.z > lastAddedPlane.position.z + 128f)
        {
            RemoveOldestPlane();
        }

        if (character.position.z > lastAddedPlane.position.z - 60f)
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
         newPlane = Instantiate(planePrefab, lastAddedPlane.transform.position + new Vector3(0, 0, 200f), Quaternion.Euler(0f,0f,0f), gameObject.transform);
        
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


