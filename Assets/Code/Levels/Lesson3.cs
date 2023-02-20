using static LessonsCompleted;

public class Lesson3 : Lesson
{
    // Drag and drop objects in

    private void Start()
    {
        part1.SetActive(!Lesson3Completed);
        finalPart.SetActive(Lesson3Completed);
    }

    public void CompletedLesson()
    {
        Lesson3CompletedOnce = true;
        Lesson3Completed = true;
        part1.SetActive(false);
        finalPart.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson3Completed = false;
    }
}
