using UnityEngine;
using static LessonsCompleted;

public class Lesson6 : Lesson
{
    // Play/Pause usage
    [SerializeField]
    protected GameObject part2;

    private void Start()
    {
        part1.SetActive(!Lesson6Completed);
        part2.SetActive(false);
        finalPart.SetActive(Lesson6Completed);
    }

    public void Part2()
    {
        part2.SetActive(true);

        part1.SetActive(false);
        finalPart.SetActive(false);
    }

    public void CompletedLesson()
    {
        Lesson6CompletedOnce = true;
        Lesson6Completed = true;

        part1.SetActive(false);
        part2.SetActive(true);
        finalPart.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson6Completed = false;
    }

}
