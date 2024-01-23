using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionCar : MonoBehaviour
{
    public List<QuestionsWithOptionsC> questionList;
    public TMP_Text QuestionDisplayGameObject;
    public TMP_Text Option1;
    public TMP_Text Option2;
    public int Counter = 0;
    public string op,correctOption;


    private void Start()
    {
        //Calling Once On GameStart
        Invoke("ShowQuestion", 4.01f);

    }
    public void ShowQuestion()
    {
        generateRandomOperator();
        questionList[Counter].question = questionList[Counter].var1 + op + questionList[Counter].var2; 
        QuestionDisplayGameObject.text = questionList[Counter].question;
        Option1 = GameObject.Find("InstantiateHere").transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
        Option2 = GameObject.Find("InstantiateHere").transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Text>();
        generateOptionText();

    }

    public void IfChosenCorrectOption()
    {
        Counter++;
        Debug.Log("Counter Value is " + Counter);
        ShowQuestion();
    }
    void generateRandomOperator()
    {
        int radomOperatorval = Random.Range(0, 4);
        if (radomOperatorval == 0)
        {
            op = "+";
        }
        else if (radomOperatorval == 1)
        {
            op = "-";
        }
        else if (radomOperatorval == 2)
        {
            op = "*";
        }
        else if (radomOperatorval == 3)
        {
            op = "/";
        }
    }
    void generateOptionText()
    {
        int randomValue = Random.Range(0, 2);
        Debug.Log("the random value is " + randomValue);
        if (randomValue == 0)
        {
            switch (op)
            {
                case "+":
                    Option1.text = questionList[Counter].correctOptionAdd;
                    Option2.text = questionList[Counter].incorrectOptionAdd;
                    correctOption = Option1.text;

                    break;
                case "-":
                    Option1.text = questionList[Counter].correctOptionSubtract;
                    Option2.text = questionList[Counter].incorrectOptionSubtract;
                    correctOption = Option1.text;
                    break;
                case "*":
                    Option1.text = questionList[Counter].correctOptionMultiply;
                    Option2.text = questionList[Counter].incorrectOptionMultiply;
                    correctOption = Option1.text;
                    break;
                case "/":
                    Option1.text = questionList[Counter].correctOptionDivide;
                    Option2.text = questionList[Counter].incorrectOptionDivide;
                    correctOption = Option1.text;
                    break;
            }
            
        }
        else
        {
            switch (op)
            {
                case "+":
                    Option1.text = questionList[Counter].incorrectOptionAdd;
                    Option2.text = questionList[Counter].correctOptionAdd;
                    correctOption = Option2.text;
                    break;
                case "-":
                    Option1.text = questionList[Counter].incorrectOptionSubtract;
                    Option2.text = questionList[Counter].correctOptionSubtract;
                    correctOption = Option2.text;
                    break;
                case "*":
                    Option1.text = questionList[Counter].incorrectOptionMultiply;
                    Option2.text = questionList[Counter].correctOptionMultiply;
                    correctOption = Option2.text;
                    break;
                case "/":
                    Option1.text = questionList[Counter].incorrectOptionDivide;
                    Option2.text = questionList[Counter].correctOptionDivide;
                    correctOption = Option2.text;
                    break;
            }
        }
    }
}

[System.Serializable]
public class QuestionsWithOptionsC
{

    public string var1, var2;
    public string question; 
    public string correctOptionAdd;
    public string incorrectOptionAdd;
    public string correctOptionSubtract;
    public string incorrectOptionSubtract;
    public string correctOptionMultiply;
    public string incorrectOptionMultiply;
    public string correctOptionDivide;
    public string incorrectOptionDivide;
}