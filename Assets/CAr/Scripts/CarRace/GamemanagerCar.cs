using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemanagerCar : MonoBehaviour
{
    public CountdownTimerCar countdownTimerObj;
    public PlayerScriptCar playerScriptObj;
    bool gameHasEnded = false;
    float restartDelay = 1f;
    
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
