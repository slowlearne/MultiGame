using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public CountdownTimer countdownTimerObj;
    public PlayerScript playerScriptObj;
    bool gameHasEnded = false;
    float restartDelay = 2f;
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            countdownTimerObj.canMove = false;
            print("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
