using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CountdownTimer countdownTimerObj;
    public Rigidbody rb;
    public float forwardForce;
    public float sideForce;
    public GameObject plane, leftWall, rightWall;
    private float initialPlanePosition, initialLeftWallPosition, initialRightWallPosition;
    public Animator animator;
    public RuntimeAnimatorController yourAnimatorController;
    public ParticleSystem particleEffect;
    public AudioSource audioSource;
    public AudioClip backGroundMusic;

    void Start()
    {
        initialPlanePosition = plane.transform.position.z;
        initialLeftWallPosition = leftWall.transform.position.z;
        initialRightWallPosition = rightWall.transform.position.z;
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        Invoke("PlayAnimationAfterDelay", 3f);
    }

    /*void FixedUpdate()
    {
        if (countdownTimerObj.canMove)
        {
            audioSource.PlayOneShot(audioClip);
            rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime); // Move Player forward
            PlayParticleSystem();
            if (Input.GetKey("a")) // Move player left
            {
                rb.AddForce(-sideForce, 0, 0 * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d")) // Move player right
            {
                rb.AddForce(sideForce, 0, 0 * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }

            plane.transform.Translate(0, 0, 1 * Time.fixedDeltaTime);
            leftWall.transform.Translate(0, 0, 1 * Time.fixedDeltaTime);
            rightWall.transform.Translate(0, 0, 1 * Time.fixedDeltaTime);


            // Check if the cube is approaching the end of the plane
            if (transform.position.z >= initialPlanePosition + 5f) // Adjust the threshold as needed
            {
                // Reset the plane's position to create the infinite scrolling effect
                ResetPlanePosition();
            }
        }
    }

    // Reset the plane's position
    void ResetPlanePosition()
    {
        float resetPosition = initialPlanePosition + 100f; // Adjust the distance to reset the plane
        float resetLeftPosition = initialLeftWallPosition + 100f; // Adjust the distance to reset the leftwall
        float resetRightPosition = initialRightWallPosition + 100f; // Adjust the distance to reset the rightwall

        plane.transform.position = new Vector3(0f, 0f, resetPosition);
        leftWall.transform.position = new Vector3(-8f, 0.5f, resetLeftPosition);
        rightWall.transform.position = new Vector3(8f, 0.5f, resetRightPosition);

        initialPlanePosition = resetPosition;
        initialLeftWallPosition = resetLeftPosition;
        initialRightWallPosition = resetRightPosition;
    }*/
    void FixedUpdate()
    {
        if (countdownTimerObj.canMove)
        {
            audioSource.PlayOneShot(backGroundMusic);
            rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime); // Move Player forward
            PlayParticleSystem();

#if UNITY_EDITOR
            HandleEditorInput();
#else
            HandleTouchInput();
#endif
        }
    }

   void HandleEditorInput()
    {
        if (Input.GetKey("a")) // Move player left
        {
            rb.AddForce(-sideForce, 0, 0 * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d")) // Move player right
        {
            rb.AddForce(sideForce, 0, 0 * Time.fixedDeltaTime, ForceMode.VelocityChange);
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


    public void PlayAnimationAfterDelay()
    {
        animator.runtimeAnimatorController = yourAnimatorController;
        animator.SetTrigger("ManPaddling");
    }

    void PlayParticleSystem()
    {
        // Check if the particle system is not already playing
        if (!particleEffect.isPlaying)
        {
            particleEffect.GetComponent<ParticleSystem>();
            // Play the particle system
            particleEffect.Play();
        }
    }
}
