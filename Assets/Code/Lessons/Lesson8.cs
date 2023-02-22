using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LessonsCompleted;

public class Lesson8 : Lesson
{
    // Play/Pause usage
    [SerializeField]
    private GameObject part2;

    [Header("Force")]
    [SerializeField]
    private TMP_InputField forceInputField;
    [SerializeField]
    private TMP_InputField forceExponential;

    [Header("Answers")]
    [SerializeField]
    private double forceValue;
    [SerializeField]
    private double forceExpValue;


    private void Start()
    {
        forceInputField.onValueChanged.AddListener(delegate { ForceChange(); });
        forceExponential.onValueChanged.AddListener(delegate { ForceChange(); });

        objects = new List<GameObject>() { part1, part2, finalPart };

        GameObject section;

        if (Lesson8Completed)
        {
            section = finalPart;
        }
        else if (Lesson8P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson8P1Completed = Lesson8Completed;
    }

    //Next
    public void Part2()
    {
        if (Lesson8Completed)
            return;

        Lesson8P1Completed = true;

        SetOneActive(part2);
    }

    public void CompletedLesson()
    {
        if (!Lesson8P1Completed || Lesson8Completed)
            return;

        Lesson8Completed = true;
        Lesson8CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson8P1Completed = false;

        Lesson8Completed = false;
    }

    private void ForceChange()
    {
        if (double.Parse(forceInputField.text) == forceValue && int.Parse(forceExponential.text) == forceExpValue)
            CompletedLesson();
    }
}
