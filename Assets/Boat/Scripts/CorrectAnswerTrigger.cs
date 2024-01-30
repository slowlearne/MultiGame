using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorrectAnswerTrigger : MonoBehaviour
{
    public Question questionObj;
    public Gamemanager gameManagerObj;
    public PlayerScript playerScriptObj;
    public MaintainDistanceFromCube maintainDistanceFromCubeObj;
    public float health = 3f;
    public TMP_Text Showhealth;
    private void Start()
    {
        Showhealth.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        TMP_Text checkOptionText = this.gameObject.GetComponent<TMP_Text>();
        Debug.Log("the Triggered Option text is " + checkOptionText.text);
        if (checkOptionText.text == questionObj.result.ToString())
        {
            print("The player entered through Correct option");
            maintainDistanceFromCubeObj.ShowTheInstantiatedOption();
            questionObj.IfChosenCorrectOption();
        }
        else
        {
            print("The player entered through Wrong option,So life has been decreased");
            health -= 1;
            playerScriptObj.forwardForce = playerScriptObj.forwardForce * 1.5f;
            Showhealth.text = health.ToString();
            Debug.Log("The Health of player is " + health);
            if (health == 0)
            {
                gameManagerObj.EndGame();
            }
            maintainDistanceFromCubeObj.ShowTheInstantiatedOption();
            questionObj.IfChosenCorrectOption();

        }

    }
}
