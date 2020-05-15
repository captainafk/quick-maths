using System;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class Maths : MonoBehaviour
{
    public Text mainInputField;
    public Text scoreText;
    public Text mathsText;
    private float op1;
    private float op2;
    private float result;

    public void Start()
    {
        //GameMng.score = 0;
        GenerateMath();
        scoreText.text = "Score: 0";
        mainInputField.text = "";
    }

    public void Update()
    {
        // Correct Answer
        if (mainInputField.text == result.ToString())
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().RightAnswer();
            GameMng.score += 1;
            GenerateMath();
            scoreText.text = "Score: " + GameMng.score.ToString();
            mainInputField.text = "";
        }

        if (GameMng.isGameRunning)
        {
            if (mainInputField.text.Length < 12)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    mainInputField.text += "1";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    mainInputField.text += "2";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                {
                    mainInputField.text += "3";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                {
                    mainInputField.text += "4";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
                {
                    mainInputField.text += "5";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
                {
                    mainInputField.text += "6";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
                {
                    mainInputField.text += "7";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
                {
                    mainInputField.text += "8";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
                {
                    mainInputField.text += "9";
                }
                else if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                {
                    mainInputField.text += "0";
                }
            }
            if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete))
            {
                mainInputField.text = "";
            }
        }
    }

    private void GenerateMath()
    {
        var opSelector = UnityEngine.Random.Range(0, 3);

        if (opSelector == Convert.ToDouble(Operators.sum))
        {
            op1 = UnityEngine.Random.Range(0, 10 + GameMng.score * 3);
            op2 = UnityEngine.Random.Range(2, 12 + GameMng.score * 3);

            result = op1 + op2;
            mathsText.text = op1.ToString() + " + " + op2.ToString() + " = ?";
        }
        else if (opSelector == Convert.ToDouble(Operators.sub))
        {
            op2 = UnityEngine.Random.Range(0, 10 + GameMng.score * 3);
            op1 = op2 + UnityEngine.Random.Range(0, 10 + GameMng.score * 3);

            result = op1 - op2;
            mathsText.text = op1.ToString() + " - " + op2.ToString() + " = ?";
        }
        else if (opSelector == Convert.ToDouble(Operators.mult))
        {
            op1 = UnityEngine.Random.Range(1, 1 + GameMng.score);
            op2 = UnityEngine.Random.Range(0, 1 + GameMng.score / 5);

            result = op1 * op2;
            mathsText.text = op1.ToString() + " * " + op2.ToString() + " = ?";
        }
        else if (opSelector == Convert.ToDouble(Operators.div))
        {
            op2 = UnityEngine.Random.Range(1, 3 + GameMng.score * 3);
            op1 = op2 * UnityEngine.Random.Range(1, 2 + GameMng.score);

            result = op1 / op2;
            mathsText.text = op1.ToString() + " / " + op2.ToString() + " = ?";
        }
    }

    private enum Operators
    {
        sum,
        sub,
        mult,
        div
    }
}