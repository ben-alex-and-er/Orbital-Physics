using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LessonsCompleted;

public class Lesson9 : Lesson
{
    // Merge equations usage
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

        if (Lesson9Completed)
        {
            section = finalPart;
        }
        else if (Lesson9P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson9P1Completed = Lesson9Completed;
    }

    //Calculate acc
    public void Part2()
    {
        if (Lesson9Completed)
            return;

        Lesson9P1Completed = true;

        SetOneActive(part2);
    }

    public void CompletedLesson()
    {
        if (!Lesson9P1Completed || Lesson9Completed)
            return;

        Lesson9Completed = true;
        Lesson9CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson9P1Completed = false;

        Lesson9Completed = false;
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
