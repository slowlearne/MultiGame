/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pianotester : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioSource;
    public AudioClip clip;
    Coroutine audio_coroutine;
    GameObject currentGameObject;
    private bool isTouching = false;
    public TMP_Dropdown dropdown;
    string folderName;

    List<GameObject> listOfGameobjects;
    //use enum for grandpiano ,synthesizer and 
    public void OnPointerDown(PointerEventData eventData)
    {
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
        *//*  currentGameObject = EventSystem.current.currentSelectedGameObject;
          startCheckingForSwipe = true;

          string gameobjectname = gameObject.name;
          clip = Resources.Load<AudioClip>(gameobjectname);

          if (audio_coroutine != null)
          {
              StopCoroutine(audio_coroutine);
              audioSource.volume = 1;
          }
          audioSource.PlayOneShot(clip);
          audioSource.volume = audioSource.volume - 0.1f;
          audio_coroutine = StartCoroutine(VolumeLerpCoroutine());
  *//*

    }
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;
    void Start()
    {
        gameObject.AddComponent<GraphicRaycaster>();

        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();

        // Create the PointerEventData with the current event system
        pointerEventData = new PointerEventData(eventSystem);
    }

    bool startCheckingForSwipe;
    string gameObjectToPlayInSwipe;
    *//*  void Update()
      {
          if (startCheckingForSwipe)
          {
              // Check for swipe input
              if (Input.touchCount > 0)
              {
                  Touch touch = Input.GetTouch(0);
                  //touch left detect
                  if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                  {
                      // Swipe input ended, perform necessary actions
                      // ...

                      // Reset the startCheckingForSwipe flag to false
                      startCheckingForSwipe = false;
                      print("final stop");
                  }
              }
          }
      }*//*

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
                listOfGameobjects = new List<GameObject>();
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
                startCheckingForSwipe = false;
                listOfGameobjects = new List<GameObject>();
                currentlyPlayedGameObject = null;

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

                    hitObject.GetComponent<KeyButtonScript>().PlayAudio(hitObject.gameObject);


                }
            }
        }
    }
    GameObject currentlyPlayedGameObject;
    public void PlayAudio(GameObject gameObjectToPlaySoundOf)
    {
        
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
        
        listOfGameobjects.Add(gameObjectToPlaySoundOf);

        if (audio_coroutine != null)
        {
            return;
        }
        if (currentlyPlayedGameObject != null)
        {
            print("current gameobj name" + currentlyPlayedGameObject);
            print("gameObjectToPlaySoundOf from raycast" + gameObjectToPlaySoundOf);
            if (listOfGameobjects[listOfGameobjects.Count - 1] == gameObjectToPlaySoundOf)
            {
                return;
            }
            *//*if (currentlyPlayedGameObject == gameObjectToPlaySoundOf) {

                print("returning");
                return;
            }*//*
        }
        string gameobjectname = gameObjectToPlaySoundOf.name;
        clip = Resources.Load<AudioClip>(folderName + "/" + gameobjectname);

        *//*   if (audio_coroutine != null)
           {

               StopCoroutine(audio_coroutine);
               audioSource.volume = 1;
           }*//*
        currentlyPlayedGameObject = gameObjectToPlaySoundOf;
        audioSource.PlayOneShot(clip);
        print("audio is played" + currentlyPlayedGameObject.name);
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
        *//*        startCheckingForSwipe = false;
        *//*
    }
}*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pianotester : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioClip clip;
    Coroutine audio_coroutine;
    GameObject currentGameObject;
    private bool isTouching = false;

    List<GameObject> listOfGameobjects;
    string recentlyPlayedGameObjectString;
    static GameObject recentPlayedGameObject;

    //use enum for grandpiano ,synthesizer and 

    
    public void OnPointerDown(PointerEventData eventData)
    {

        recentPlayedGameObject = gameObject;
      
        recentlyPlayedGameObjectString = gameObject.name;
        print("foldername is:" + PanelController.folderName);
        clip = Resources.Load<AudioClip>(PanelController.folderName + "/" + recentlyPlayedGameObjectString);

        if (audio_coroutine != null)
        {
            StopCoroutine(audio_coroutine);
            audioSource.volume = 1;
        }
        audioSource.PlayOneShot(clip);
        audioSource.volume = audioSource.volume - 0.1f;
        audio_coroutine = StartCoroutine(VolumeLerpCoroutine());


    }


    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;
    void Start()
    {
        clip = Resources.Load<AudioClip>(PanelController.folderName + "/" + gameObject.name);
        audioSource.clip = clip;
        print("clip name is:" + clip.name);
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
                // Reset the recentPlayedGameObject at the beginning of a touch
                recentPlayedGameObject = null;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Reset the recentPlayedGameObject at the end of a touch
                recentPlayedGameObject = null;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                pointerEventData.position = touch.position;

                List<RaycastResult> results = new List<RaycastResult>();
                raycaster.Raycast(pointerEventData, results);

                if (results.Count < 1) return;

                GameObject currentGameObject = results[0].gameObject;

                if (currentGameObject.GetComponent<pianotester>() == null)
                {
                    return;
                }

                if (recentPlayedGameObject == currentGameObject)
                {
                    return; // Skip execution if the recently played game object is the same as the currently hit game object
                }

                recentPlayedGameObject = currentGameObject;

                currentGameObject.GetComponent<pianotester>().changeRecentlyPlayedGameObject(currentGameObject);
                // currentGameObject.GetComponent<KeyButtonScript>().PlayAudioTest(currentGameObject);
            }
        }
    }

    void changeRecentlyPlayedGameObject(GameObject recentplayedGameObjects)
    {
        Debug.LogError("reached here");
        recentPlayedGameObject = recentplayedGameObjects;
        print("recentplayedgameobject is: " + recentPlayedGameObject);
        clip = Resources.Load<AudioClip>(PanelController.folderName + "/" + recentplayedGameObjects.name);


       /*AudioClip clip = Resources.Load<AudioClip>( recentplayedGameObjects.name);*/
      audioSource.PlayOneShot(clip);


        print("audio is played" + recentplayedGameObjects.name);
        audio_coroutine = StartCoroutine(VolumeLerpCoroutine());
        /*        print("after changed gameobject name" + recentPlayedGameObject);*/
        
    }
    GameObject currentlyPlayedGameObject;

    
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
}

