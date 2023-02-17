using static LessonsCompleted;

public class Lesson5 : Lesson
{
    // Play/Pause usage

    private void Start()
    {
        beforeLesson.SetActive(!Lesson5Completed);
        afterLesson.SetActive(Lesson5Completed);
    }

    public void CompletedLesson()
    {
        Lesson5Completed = true;
        beforeLesson.SetActive(false);
        afterLesson.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson5Completed = false;
    }

}
