using UnityEngine;
using static LessonsCompleted;

public class Lesson6 : Lesson
{
    // Quaternary
    private void Start()
    {
        part1.SetActive(!Lesson6Completed);
        finalPart.SetActive(Lesson6Completed);
    }

    public void CompletedLesson()
    {
        Lesson6CompletedOnce = true;
        Lesson6Completed = true;
        part1.SetActive(false);
        finalPart.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson6Completed = false;
    }
}
