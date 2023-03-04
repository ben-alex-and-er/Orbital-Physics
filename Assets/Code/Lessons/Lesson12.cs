using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LessonsCompleted;

public class Lesson12 : Lesson
{
    // 3D usage
    [SerializeField]
    private GameObject part2;

    private void Start()
    {
        objects = new List<GameObject>() { part1, part2, finalPart };

        GameObject section;

        if (Lesson12Completed)
        {
            section = finalPart;
        }
        else if (Lesson12P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson12P1Completed = Lesson12Completed;
    }

    //Pause
    public void Part2()
    {
        if (Lesson12Completed)
            return;

        Lesson12P1Completed = true;

        SetOneActive(part2);
    }

    public void CompletedLesson()
    {
        if (!Lesson12P1Completed || Lesson12Completed)
            return;

        Lesson12Completed = true;
        Lesson12CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson12P1Completed = false;

        Lesson12Completed = false;
    }
}
