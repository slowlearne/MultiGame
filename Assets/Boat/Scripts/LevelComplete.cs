using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public CountdownTimer countdownTimerObj;
    public void LoadNextLevel()
    {
        Debug.Log("Next scene loaded");
        countdownTimerObj.countdownTime = 3f;
        countdownTimerObj.canMove = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
