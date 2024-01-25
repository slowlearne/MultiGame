using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseNumberOfPlayer : MonoBehaviour
{
    public int numberOfPlayerChosen;
    public Button twoPlayer;
    public Button threePlayer;
    public Button fourPlayer;
    public GameObject chooseNumberOfPlayer;
    public GameManagerSL gameManagerSLobj;
    public GameObject player2Icon, player4Icon;

    public void PlayTwoPlayer()
    {
        numberOfPlayerChosen = 2;
        gameManagerSLobj.player2.SetActive(false);
        player2Icon.SetActive(false);
        gameManagerSLobj.player4.SetActive(false);
        player4Icon.SetActive(false);
        chooseNumberOfPlayer.SetActive(false);
        print("The Total no. of Player are " + numberOfPlayerChosen);
        
    }
    public void PlayThreePlayer()
    {
        numberOfPlayerChosen = 3;
        gameManagerSLobj.player2.SetActive(false);
        player2Icon.SetActive(false);
        chooseNumberOfPlayer.SetActive(false);
        print("The Total no. of Player are " + numberOfPlayerChosen);
    }
    public void PlayFourPlayer()
    {
        numberOfPlayerChosen = 4;
        chooseNumberOfPlayer.SetActive(false);
        print("The Total no. of Player are " + numberOfPlayerChosen);
    }

    public void GoBackToMenu()
    {
        chooseNumberOfPlayer.SetActive(true);
    }

}
