using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform playerpos;
    public TMP_Text displayTextScore;

    private float currentScore = 0f;
    private float highestScore = 0f;

    void Update()
    {
        // Update the current score based on the player's position
        currentScore = playerpos.position.z;

        // Update the display text with the current score
        displayTextScore.text = currentScore.ToString("0");

        // Check if the current score is higher than the highest score
        if (currentScore > highestScore)
        {
            // Update the highest score
            highestScore = currentScore;
        }
    }

    // You can use this function to retrieve the highest score from other scripts
    public float GetHighestScore()
    {
        return highestScore;
    }
}
