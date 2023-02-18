using static LessonsCompleted;

public class Lesson6 : Lesson
{
    // Play/Pause usage

    private void Start()
    {
        beforeLesson.SetActive(!Lesson6Completed);
        afterLesson.SetActive(Lesson6Completed);
    }

    public void CompletedLesson()
    {
        Lesson6Completed = true;
        beforeLesson.SetActive(false);
        afterLesson.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson6Completed = false;
    }

}
