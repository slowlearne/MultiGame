/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public PlayerScript playerMovement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("we hit an obstacle");
            playerMovement.enabled = false;
            Debug.Log("movement halted");
            FindObjectOfType<Gamemanager>().EndGame();
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionCar : MonoBehaviour
{
    public PlayerScriptCar playerMovement;
    private Quaternion originalRotation;
    public AudioSource crashAudioSource;
    public AudioClip crashSound;

    void Start()
    {
        // Store the original rotation when the script starts
        originalRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("We hit an obstacle");
            playerMovement.enabled = false;
            crashAudioSource.PlayOneShot(crashSound);
            Debug.Log("Movement halted");
            FindObjectOfType<GamemanagerCar>().EndGame();

            // Reset the rotation using Quaternion.Lerp
            
        }
        StartCoroutine(RotateBackToOriginalRotation());
    }

    IEnumerator RotateBackToOriginalRotation()
    {
        float elapsedTime = 0f;
        float duration = 1f; // Adjust the duration as needed

        Quaternion currentRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Lerp(currentRotation, originalRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure that the rotation is exactly the original rotation when the lerp is complete
        transform.rotation = originalRotation;
    }
}
