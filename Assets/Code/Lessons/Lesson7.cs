using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LessonsCompleted;

public class Lesson7 : Lesson
{
    // Event horizon
    [SerializeField]
    private GameObject part2;

    [Header("Mass")]
    [SerializeField]
    private TMP_InputField massInputField;
    [SerializeField]
    private TMP_InputField massExponential;

    [Header("Answers")]
    [SerializeField]
    private double massValue = 4;
    [SerializeField]
    private double massExpValue = 31;


    private void Start()
    {
        massInputField.onValueChanged.AddListener(delegate { MassChange(); });
        massExponential.onValueChanged.AddListener(delegate { MassChange(); });

        objects = new List<GameObject>() { part1, part2, finalPart };

        GameObject section;

        if (Lesson7Completed)
        {
            section = finalPart;
        }
        else if (Lesson7P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson7P1Completed = Lesson7Completed;
    }

    //Pause
    public void Part2()
    {
        if (Lesson7Completed)
            return;

        Lesson7P1Completed = true;

        SetOneActive(part2);
    }

    public void CompletedLesson()
    {
        if (!Lesson7P1Completed || Lesson7Completed)
            return;

        Lesson7Completed = true;
        Lesson7CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson7P1Completed = false;

        Lesson7Completed = false;
    }

    private void MassChange()
    {
        if (double.Parse(massInputField.text) == massValue && int.Parse(massExponential.text) == massExpValue)
            CompletedLesson();
    }
}
