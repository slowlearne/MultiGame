using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaintainDistanceFromCar : MonoBehaviour
{
    public Transform player; // Drag your cube GameObject here in the Unity Editor
    public TextMeshPro[] triggers; // Drag your TextMeshPro GameObjects here in the Unity Editor
    public Transform gameObjectToInstantiateOn;
    public GameObject options;
    public List<GameObject> ListOfInstantiatedOptions;
    GameObject item1, item2;
    private void Start()
    {
        item1 = Instantiate(options, gameObjectToInstantiateOn.transform.position, Quaternion.identity, gameObjectToInstantiateOn);
        ListOfInstantiatedOptions.Add(item1);
        item2 = Instantiate(options, gameObjectToInstantiateOn.transform.position, Quaternion.identity, gameObjectToInstantiateOn);
        ListOfInstantiatedOptions.Add(item2);

        print("ListOfInstantiatedOptions has " + ListOfInstantiatedOptions.Count);
        Invoke("ShowTheInstantiatedOption", 4f);


    }

    public void ShowTheInstantiatedOption()
    {
        print("After 3 seconds, the Options Has appeared");
        item1.transform.position = new Vector3(-5.67f, 3f, player.position.z + 90f);
        item2.transform.position = new Vector3(5f, 3f, player.position.z + 90f);

    }
}
