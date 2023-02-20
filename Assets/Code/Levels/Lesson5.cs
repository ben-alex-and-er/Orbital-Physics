using static LessonsCompleted;

public class Lesson5 : Lesson
{
    // Play/Pause usage

    private void Start()
    {
        part1.SetActive(!Lesson5Completed);
        finalPart.SetActive(Lesson5Completed);
    }

    public void CompletedLesson()
    {
        Lesson5CompletedOnce = true;
        Lesson5Completed = true;
        part1.SetActive(false);
        finalPart.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson5Completed = false;
    }

}
