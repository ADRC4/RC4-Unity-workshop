using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCode : MonoBehaviour
{
    public GUISkin skin;
    string text;

    void Start()
    {
        var numbers = Fibonacci(0, 1, 10);
        string numbersAsText = string.Join(", ", numbers);
        text =  $"<b>Result:</b> {numbersAsText}";
    }


    List<int> Fibonacci(int first, int second, int length)
    {
        var numbers = new List<int>();
        numbers.Add(first);
        numbers.Add(second);

        for (int i = 0; i < length; i++)
        {
            var last = numbers[numbers.Count - 1];
            var lastButOne = numbers[numbers.Count - 2];

            numbers.Add(last + lastButOne);
        }

        return numbers;
    }



    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(10, 10, 500, 50), text);
    }
}