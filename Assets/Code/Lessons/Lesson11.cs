using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LessonsCompleted;

public class Lesson11 : Lesson
{
    // Force calculation
    [SerializeField]
    private GameObject part2;

    [Header("Mass")]
    [SerializeField]
    private TMP_InputField massInputField;
    [SerializeField]
    private TMP_InputField massExponential;

    [Header("Answers")]
    [SerializeField]
    private double massValue;
    [SerializeField]
    private double massExpValue;


    private void Start()
    {
        massInputField.onValueChanged.AddListener(delegate { MassChange(); });
        massExponential.onValueChanged.AddListener(delegate { MassChange(); });

        objects = new List<GameObject>() { part1, part2, finalPart };

        GameObject section;

        if (Lesson11Completed)
        {
            section = finalPart;
        }
        else if (Lesson11P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson11P1Completed = Lesson11Completed;
    }

    //Next
    public void Part2()
    {
        if (Lesson11Completed)
            return;

        Lesson11P1Completed = true;

        SetOneActive(part2);
    }

    public void CompletedLesson()
    {
        if (!Lesson11P1Completed || Lesson11Completed)
            return;

        Lesson11Completed = true;
        Lesson11CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson11P1Completed = false;

        Lesson11Completed = false;
    }

    private void MassChange()
    {
        if (double.Parse(massInputField.text) == massValue && int.Parse(massExponential.text) == massExpValue)
            CompletedLesson();
    }
}
