using System;
using System.Collections.Generic;
using UnityEngine;
using static LessonsCompleted;

public class Lesson3 : Lesson
{
    // Drag and drop objects in
    [HideInInspector]
    public Object2D newPlanet;

    [SerializeField]
    private GameObject part2;
    [SerializeField]
    private GameObject part3;

    [Header("Planets")]
    [SerializeField]
    private PlanetEditor2D planetEditor;
    [SerializeField]
    private List<Object2D> objectsToNotTrack;

    private const float Threshold = 1;

    private void Start()
    {
        objects = new List<GameObject>() { part1, part2, part3, finalPart };

        GameObject section;

        if (Lesson3Completed)
        {
            section = finalPart;
        }
        else if (Lesson3P2Completed)
        {
            section = part3;
        }
        else if (Lesson3P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson3P1Completed = Lesson3Completed;
        Lesson3P2Completed = Lesson3Completed;
    }

    private void Update()
    {
        if (!objectsToNotTrack.Contains(planetEditor.planet) && newPlanet != null && Math.Abs(newPlanet.velocity.x) > Threshold)
            Part3();
    }

    //Change velocity
    public void Part2(Object2D obj)
    {
        if (Lesson3P2Completed || Lesson3Completed)
            return;

        newPlanet = obj;

        Lesson3P1Completed = true;

        SetOneActive(part2);
    }

    //Reset
    public void Part3()
    {
        if (!Lesson3P1Completed || Lesson3Completed)
            return;

        Lesson3P2Completed = true;

        SetOneActive(part3);
    }

    public void CompletedLesson()
    {
        if (!Lesson3P1Completed || !Lesson3P2Completed || Lesson3Completed)
            return;

        Lesson3Completed = true;
        Lesson3CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson3P1Completed = false;
        Lesson3P2Completed = false;

        Lesson3Completed = false;
    }
}
