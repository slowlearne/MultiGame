using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptCar : MonoBehaviour
{
    public CountdownTimerCar countdownTimerObj;
    public Rigidbody rb;
    public float forwardForce;
    public float sideForce;
    public GameObject plane, leftWall, rightWall;
    private float initialPlanePosition, initialLeftWallPosition, initialRightWallPosition;
    public AudioSource audioSource;
    public AudioSource CarStartAudio;
    public AudioClip startClip;
    public AudioClip audioClip;
    void Start()
    {
        initialPlanePosition = plane.transform.position.z;
        initialLeftWallPosition = leftWall.transform.position.z;
        initialRightWallPosition = rightWall.transform.position.z;
        Invoke("playStartCarSound", 2f);
    }

   void playStartCarSound()
    {
        audioSource.PlayOneShot(startClip);
    }
    void FixedUpdate()
    {
        if (countdownTimerObj.canMove)
        {
            /*audioSource.PlayOneShot(audioClip);*/
            /*rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);   */                // Move Player forward
            audioSource.PlayOneShot(audioClip);

            // Handle touch input for left and right movement
            /*HandleTouchInput();*/
        }
    }

    void HandleTouchInput()
    {
        // Check if there is a touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if it's the beginning of the touch
            if (touch.phase == TouchPhase.Began)
            {
                // Check if the touch is on the left or right side of the screen
                if (touch.position.x < Screen.width / 2)
                {
                    // Move a little to the left
                    rb.AddForce(new Vector3(-sideForce, 0, 0), ForceMode.VelocityChange);
                }
                else
                {
                    // Move a little to the right
                    rb.AddForce(new Vector3(sideForce, 0, 0), ForceMode.VelocityChange);
                }
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // If the touch is moved or stationary, continue moving left or right
                if (touch.position.x < Screen.width / 2)
                {
                    // Move continuously to the left
                    rb.AddForce(new Vector3(-sideForce, 0, 0), ForceMode.VelocityChange);
                }
                else
                {
                    // Move continuously to the right
                    rb.AddForce(new Vector3(sideForce, 0, 0), ForceMode.VelocityChange);
                }
            }
        }
    }
}
