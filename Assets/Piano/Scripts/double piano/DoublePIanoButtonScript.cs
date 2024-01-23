using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class DoublePIanoButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;
    public AudioClip clip;
    Coroutine audio_coroutine;
    GameObject currentGameObject;
    private bool isTouching = false;
    public TMP_Dropdown dropdown;
    string folderName;
    private Vector3 originalScale;
    List<GameObject> listOfGameobjects;
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;
   
    public void OnPointerDown(PointerEventData eventData)
    {
        print("pointer down is called");
        transform.localScale = new Vector3(0.96f, 0.96f, 0.96f);
        currentGameObject = EventSystem.current.currentSelectedGameObject;
        startCheckingForSwipe = true;
        string gameobjectname = gameObject.name;
        switch (dropdown.value)
        {
            case 0:
                folderName = "Keys";
                print("foldernameis" + folderName);
                break;
            case 1:
                folderName = "ElectricPiano";
                print("foldernameis" + folderName);
                break;
            case 2:
                folderName = "GrandPiano";
                print("foldernameis" + folderName);
                break;
        }
        clip = Resources.Load<AudioClip>(folderName + "/" + gameobjectname);

        if (audio_coroutine != null)
        {
            StopCoroutine(audio_coroutine);
            audioSource.volume = 1;
        }
        audioSource.PlayOneShot(clip);
        Debug.Log("purano volume" + audioSource.volume);
        audioSource.volume = audioSource.volume - 0.1f;
        Debug.Log("naya volume" + audioSource.volume);
        audio_coroutine = StartCoroutine(VolumeLerpCoroutine());


    }
    
    void Start()
    {
        originalScale = transform.localScale;
        gameObject.AddComponent<GraphicRaycaster>();

        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();

        // Create the PointerEventData with the current event system
        pointerEventData = new PointerEventData(eventSystem);
    }

    bool startCheckingForSwipe;
    string gameObjectToPlayInSwipe;
    bool initialTouch;
    List<GameObject> keysCollection;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouching = true;
                initialTouch = true;
                keysCollection = new List<GameObject>();
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
                startCheckingForSwipe = false;
                keysCollection = new List<GameObject>();

            }

            if (isTouching)
            {

                pointerEventData.position = touch.position;

                List<RaycastResult> results = new List<RaycastResult>();
                raycaster.Raycast(pointerEventData, results);

                if (results.Count < 1) return;
                currentGameObject = results[0].gameObject;

                if (currentGameObject.GetComponent<KeyButtonScript>() == null)
                {
                    return;
                }
                foreach (RaycastResult result in results)
                {

                    GameObject hitObject = result.gameObject;
                    Debug.Log("Hit UI Object: " + hitObject.name);
                    Debug.Log("Current gameobj name: " + currentGameObject.name);
                    hitObject.GetComponent<KeyButtonScript>().PlayAudio(hitObject.gameObject);


                }
            }
        }
    }

    public void PlayAudio(GameObject gameObjectToPlaySoundOf)
    {
        print("audio is played");
        if (audio_coroutine != null) return;
        string gameobjectname = gameObjectToPlaySoundOf.name;

        // Determine the folder name based on the chosen option
        //string folderName = "";
        switch (dropdown.value)
        {
            case 0:
                folderName = "Keys";
                print("foldernameis" + folderName);
                break;
            case 1:
                folderName = "ElectricPiano";
                print("foldernameis" + folderName);
                break;
            case 2:
                folderName = "GrandPiano";
                print("foldernameis" + folderName);
                break;
        }
        clip = Resources.Load<AudioClip>(folderName + "/" + gameobjectname);

        /*   if (audio_coroutine != null)
           {

               StopCoroutine(audio_coroutine);
               audioSource.volume = 1;
           }*/
        audioSource.PlayOneShot(clip);

        audio_coroutine = StartCoroutine(VolumeLerpCoroutine());
    }

    float duration = 1f;
    private IEnumerator VolumeLerpCoroutine()
    {
        float timer = 0f;
        float startVolume = 1f;
        float targetVolume = 0f;
        while (timer < duration)
        {
            timer = timer + Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);
            float volume = Mathf.Lerp(startVolume, targetVolume, t);
            audioSource.volume = volume;
            yield return null;
        }

        audio_coroutine = null;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("pointer up is called");
        transform.localScale = originalScale;
        /*        startCheckingForSwipe = false;
        */
    }
}