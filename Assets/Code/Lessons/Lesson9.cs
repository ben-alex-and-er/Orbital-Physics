using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LessonsCompleted;

public class Lesson9 : Lesson
{
    // Play/Pause usage
    [SerializeField]
    private GameObject part2;

    [Header("Force")]
    [SerializeField]
    private TMP_InputField G;
    [SerializeField]
    private TMP_InputField m;
    [SerializeField]
    private TMP_InputField r;

    [Header("Acceleration")]
    [SerializeField]
    private TMP_InputField accInputField;
    [SerializeField]
    private TMP_InputField accExponential;

    [Header("Answers")]
    [SerializeField]
    private double accValue;
    [SerializeField]
    private double accExpValue;


    private void Start()
    {
        G.onValueChanged.AddListener(delegate { EqChange(); });
        m.onValueChanged.AddListener(delegate { EqChange(); });
        r.onValueChanged.AddListener(delegate { EqChange(); });

        accInputField.onValueChanged.AddListener(delegate { AccChange(); });
        accExponential.onValueChanged.AddListener(delegate { AccChange(); });

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

    //Calculate acc
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

    private void EqChange()
    {
        if (G.text == "G")
        {
            if (m.text == "m" && r.text == "r")
                Part2();
        }
        else if (G.text == "m")
        {
            if (m.text == "G" && r.text == "r")
                Part2();
        }
    }

    private void AccChange()
    {
        if (double.Parse(accInputField.text) == accValue && int.Parse(accExponential.text) == accExpValue)
            CompletedLesson();
    }
}
