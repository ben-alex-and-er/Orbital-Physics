using static LessonsCompleted;

public class Lesson4 : Lesson
{
    // Binary
    private void Start()
    {
        part1.SetActive(!Lesson4Completed);
        finalPart.SetActive(Lesson4Completed);
    }

    public void CompletedLesson()
    {
        Lesson4CompletedOnce = true;
        Lesson4Completed = true;
        part1.SetActive(false);
        finalPart.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson4Completed = false;
    }
}
