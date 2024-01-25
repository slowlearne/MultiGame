using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptCar : MonoBehaviour
{
    public CountdownTimerCar countdownTimerObj;
    public GamemanagerCar gamemanagerCarObj;
    public Rigidbody rb;
    public float forwardForce;
    public float sideForce;
    public GameObject plane, leftWall, rightWall;
    private float initialPlanePosition, initialLeftWallPosition, initialRightWallPosition;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float initialSpeed = 10.0f;
    public float acceleration = 0.1f;
    public float sideSpeed = 5.0f;
    private float currentSpeed;
    public float rotationSpeed = 5.0f;
    //wheel rotate
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }
    public List<Wheel> wheels;

    void Start()
    {
        currentSpeed = initialSpeed;    
        rb = GetComponent<Rigidbody>();
        initialPlanePosition = plane.transform.position.z;
        initialLeftWallPosition = leftWall.transform.position.z;
        initialRightWallPosition = rightWall.transform.position.z;
        Invoke("playStartCarSound", 2f);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = true;
        Invoke("Playaudio", 3f);
    }

   void Playaudio()
    {
        audioSource.Play();
    }
    void FixedUpdate()
    {
        if (countdownTimerObj.canMove)
        {

           
           
            /*rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);   */                // Move Player forward

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            currentSpeed += acceleration * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * sideSpeed * Time.deltaTime);
            AnimateWheels();
          
            if (transform.position.y < -1f)
            {
                gamemanagerCarObj.EndGame();
            }
        }
        
        // Handle touch input for left and right movement
        /*HandleTouchInput();*/
    }
    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion currentRotation = wheel.wheelModel.transform.rotation; 
            Quaternion newRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime, 0, 0) * currentRotation;
            wheel.wheelModel.transform.rotation = newRotation;
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
    


/*public float speed = 10.0f;
private Rigidbody rb;

void Start()
{
    rb = GetComponent<Rigidbody>();
}

void FixedUpdate()
{
    float moveZ = Input.GetAxis("Vertical") * speed;
    rb.MovePosition(rb.position + transform.forward * moveZ * Time.fixedDeltaTime);
}*/