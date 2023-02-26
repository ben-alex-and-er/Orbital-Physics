using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static LessonsCompleted;

public class Lesson10 : Lesson
{
    // Solar system usage
    [SerializeField]
    private GameObject part2;

    [SerializeField]
    private List<Object2D> giants;

    private void Start()
    {
        objects = new List<GameObject>() { part1, part2, finalPart };

        GameObject section;

        if (Lesson10Completed)
        {
            section = finalPart;
        }
        else if (Lesson10P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson10P1Completed = Lesson10Completed;
    }

    //Pause
    public void Part2()
    {
        if (Lesson10Completed)
            return;

        Lesson10P1Completed = true;

        SetOneActive(part2);
    }

    public void CompletedLesson(Object2D planet)
    {
        if (!Lesson10P1Completed || Lesson10Completed || !giants.Contains(planet))
            return;

        Lesson10Completed = true;
        Lesson10CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson10P1Completed = false;

        Lesson10Completed = false;
    }
}
