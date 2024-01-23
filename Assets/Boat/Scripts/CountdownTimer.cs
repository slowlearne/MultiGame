using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountdownTimer : MonoBehaviour
{
    public TMP_Text countdownText;
    public float countdownTime = 3f;
    public bool canMove;

    private void Start()
    {
        // Start the countdown when the script is initialized
        StartCountdown();
    }

    private void StartCountdown()
    {
        // Invoke the Countdown function with a delay of 1 second, and repeat it every second
        InvokeRepeating("Countdown", 1f, 1f);
    }

    private void Countdown()
    {
        // Decrease the countdown time by 1 second
        countdownTime -= 1f;

        // Update the UI text to display the current countdown time
        countdownText.text = Mathf.Ceil(countdownTime).ToString();

        // Check if the countdown has reached 0
        if (countdownTime <= 0f)
        {
            // Countdown is complete, you can perform any actions you need here
            countdownText.text = "Go!"; // Optional message when countdown is complete
            canMove = true;
            CancelInvoke("Countdown"); // Stop the countdown
            Invoke("EmptyCountdownText", 0.5f);
        }
    }
    public void EmptyCountdownText()
    {
        countdownText.text = "";
    }
}
