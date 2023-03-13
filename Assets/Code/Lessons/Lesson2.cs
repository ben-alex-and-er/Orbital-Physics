using System;
using System.Collections.Generic;
using UnityEngine;
using static LessonsCompleted;

public class Lesson2 : Lesson
{
    // Changing Mass break binary orbit
    [SerializeField]
    private GameObject part2;
    [SerializeField]
    private GameObject part3;
    [SerializeField]
    private GameObject part4;
    [SerializeField]
    private GameObject part5;
    [SerializeField]
    private GameObject part6;

    [Header("Planets")]

    [SerializeField]
    private BaseObject planet;
    [SerializeField]
    private BaseObject sun;
    [SerializeField]
    private Collider2D sunClick;

    [SerializeField]
    private PlanetEditor2D planetEditor;

    private double planetStartMass;
    private double sunStartMass;

    private const ulong Threshold = 10000000000000000000;
    private const int SunDiff = 10000;
    private bool part2Once;

    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>() { part1, part2, part3, part4, part5, part6, finalPart };

        GameObject section;

        if (Lesson2Completed)
        {
            section = finalPart;
        }
        else if (Lesson2P5Completed)
        {
            section = part6;
        }
        else if (Lesson2P4Completed)
        {
            section = part5;
        }
        else if (Lesson2P3Completed)
        {
            section = part4;
        }
        else if (Lesson2P2Completed)
        {
            section = part3;
        }
        else if (Lesson2P1Completed)
        {
            section = part2;
        }
        else
        {
            section = part1;
        }

        SetOneActive(section);

        Lesson2P1Completed = Lesson2Completed;
        Lesson2P2Completed = Lesson2Completed;
        Lesson2P3Completed = Lesson2Completed;
        Lesson2P4Completed = Lesson2Completed;

        planetStartMass = planet.mass;
        sunStartMass = sun.mass;

        sunClick.enabled = Lesson2P3Completed;
    }

    private void Update()
    {
        if (Math.Abs(planetStartMass - planet.mass) > Threshold && !part2Once)
        {
            Part2();
        }

        if (planetEditor.planet == sun)
        {
            Part5();
        }
        
        if (Math.Abs(sunStartMass - sun.mass) / SunDiff > Threshold)
        {
            Part6();
        }
    }

    //Change planet mass
    public void Part2()
    {
        if (Lesson2P2Completed || Lesson2P3Completed || Lesson2P4Completed || Lesson2P5Completed || Lesson2Completed)
            return;

        part2Once = true;
        Lesson2P1Completed = true;

        SetOneActive(part2);
    }

    //Play
    public void Part3()
    {
        if (!Lesson2P1Completed || Lesson2P3Completed || Lesson2P4Completed || Lesson2P5Completed || Lesson2Completed)
            return;

        Lesson2P2Completed = true;

        SetOneActive(part3);
    }

    //Pause
    public void Part4()
    {
        if (!Lesson2P1Completed || !Lesson2P2Completed || Lesson2P4Completed || Lesson2P5Completed || Lesson2Completed)
            return;

        Lesson2P3Completed = true;
        sunClick.enabled = true;

        SetOneActive(part4);
    }

    //Click on Sun
    public void Part5()
    {
        if (!Lesson2P1Completed || !Lesson2P2Completed || !Lesson2P3Completed || Lesson2P5Completed || Lesson2Completed)
            return;

        Lesson2P4Completed = true;

        SetOneActive(part5);
    }

    //Play
    public void Part6()
    {
        if (!Lesson2P1Completed || !Lesson2P2Completed || !Lesson2P3Completed || !Lesson2P4Completed || Lesson2Completed)
            return;

        Lesson2P5Completed = true;

        SetOneActive(part6);
    }

    public void CompletedLesson()
    {
        if (!Lesson2P1Completed || !Lesson2P2Completed || !Lesson2P3Completed || !Lesson2P4Completed || !Lesson2P5Completed)
            return;

        Lesson2Completed = true;
        Lesson2CompletedOnce = true;

        SetOneActive(finalPart);
    }

    public void ResetLesson()
    {
        Lesson2P1Completed = false;
        Lesson2P2Completed = false;
        Lesson2P3Completed = false;
        Lesson2P4Completed = false;
        Lesson2P5Completed = false;

        Lesson2Completed = false;
    }
}
