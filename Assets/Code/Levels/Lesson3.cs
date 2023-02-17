using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LessonsCompleted;

public class Lesson3 : Lesson
{
    // Drag and drop objects in

    private void Start()
    {
        beforeLesson.SetActive(!Lesson3Completed);
        afterLesson.SetActive(Lesson3Completed);
    }

    public void CompletedLesson()
    {
        Lesson3Completed = true;
        beforeLesson.SetActive(false);
        afterLesson.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson3Completed = false;
    }
}
