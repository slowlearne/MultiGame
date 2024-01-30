using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{
    public TMP_Text QuestionDisplayGameObject;
    public TMP_Text Option1;
    public TMP_Text Option2;
    public int Counter = 0;
    public string op, OprForIncorrect;
    public float result = 0;
    float incorrectResult = 0;

    private void Start()
    {
        //Calling Once On GameStart
        Invoke("ShowQuestion", 4.01f);

    }
    public void ShowQuestion()
    {
        generateRandomOperator();
        float A = Random.Range(1, 100);
        float B;
        do
        {
            B = Random.Range(2, 100);
        } while (A % B != 0);

        print("the value of A is: " + A);
        print("the value of B is: " + B);
        Option1 = GameObject.Find("InstantiateHere").transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>();
        Option2 = GameObject.Find("InstantiateHere").transform.GetChild(1).transform.GetChild(0).GetComponent<TMP_Text>();
        QuestionDisplayGameObject.text = A + op + B;

        switch (op)
        {
            case "+":
                result = A + B;
                break;
            case "-":
                result = A - B;
                break;
            case "*":
                result = A * B;
                break;
            case "/":
                result = A / B; 
                break;
        }

        Debug.Log("A: " + A);
        Debug.Log("B: " + B);
        Debug.Log("Operator: " + op);
        Debug.Log("Result: " + result);

        float incorrectValue = Random.Range(1, 3);

        generateIncorrectRandomOperator();
        print("random operator for incorect option is " + OprForIncorrect);

        switch (OprForIncorrect)
        {
            case "+":
                incorrectResult = result + incorrectValue;
                break;
            case "-":
                incorrectResult = result - incorrectValue;
                break;
        }
        GenerateRandomValueToShowOption();

    }

    void GenerateRandomValueToShowOption()
    {
        int val = Random.Range(0, 2);
        if (val == 0)
        {
            Option1.text = result.ToString();
            Option2.text = incorrectResult.ToString();
        }
        else
        {
            Option1.text = incorrectResult.ToString();
            Option2.text = result.ToString();
        }
    }
    public void IfChosenCorrectOption()
    {
        Counter++;
        Debug.Log("Counter Value is " + Counter);
        ShowQuestion();
    }
    void generateIncorrectRandomOperator()
    {
        int radomOperatorval = Random.Range(0, 2);
        if (radomOperatorval == 0)
        {
            OprForIncorrect = "+";
        }
        else
        {
            OprForIncorrect = "-";
        }
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
}
    