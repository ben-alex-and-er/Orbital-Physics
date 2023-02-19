using System;
using UnityEngine;
using static LessonsCompleted;

public class Lesson2 : Lesson
{
    // Changing Mass break binary orbit

    [Header("Planet")]

    [SerializeField]
    private BaseObject planet;

    private double startMass;
    private const ulong Threshold = 10000000000000000000;


    // Start is called before the first frame update
    void Start()
    {
        beforeLesson.SetActive(!Lesson2Completed);
        afterLesson.SetActive(Lesson2Completed);

        startMass = planet.mass;
    }

    private void Update()
    {
        if (Math.Abs(startMass - planet.mass) > Threshold)
        {
            CompletedLesson();
        }
    }

    private void CompletedLesson()
    {
        Lesson2CompletedOnce = true;
        Lesson2Completed = true;
        beforeLesson.SetActive(false);
        afterLesson.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson2Completed = false;
    }

}
