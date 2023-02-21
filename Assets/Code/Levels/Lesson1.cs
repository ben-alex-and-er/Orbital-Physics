using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LessonsCompleted;

public class Lesson1 : Lesson
{
    // Play/Pause usage
    [SerializeField]
    private GameObject part2;
    [SerializeField]
    private GameObject part3;

    [SerializeField]
    private Button resetButton;

    private void Start()
    {
        objects = new List<GameObject>() { part1, part2, part3, finalPart };

        GameObject section;

        if (Lesson1Completed)
        {
            section = finalPart;
        }
        else if (Lesson1P2Completed)
        {
            section = part3;
        }
        else if (Lesson1P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson1P1Completed = Lesson1Completed;
        Lesson1P2Completed = Lesson1Completed;
        resetButton.interactable = Lesson1Completed;
    }

    //Pause
    public void Part2()
    {
        if (Lesson1P2Completed || Lesson1Completed)
            return;

        Lesson1P1Completed = true;

        SetOneActive(part2);
    }

    //Reset
    public void Part3()
    {
        if (!Lesson1P1Completed || Lesson1Completed)
            return;

        Lesson1P2Completed = true;
        resetButton.interactable = true;

        SetOneActive(part3);
    }

    public void CompletedLesson()
    {
        if (!Lesson1P1Completed || !Lesson1P2Completed || Lesson1Completed)
            return;

        Lesson1Completed = true;
        Lesson1CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson1P1Completed = false;
        Lesson1P2Completed = false;

        Lesson1Completed = false;
    }
}
