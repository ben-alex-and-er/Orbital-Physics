using static LessonsCompleted;

public class Lesson4 : Lesson
{
    // Play/Pause usage

    private void Start()
    {
        beforeLesson.SetActive(!Lesson4Completed);
        afterLesson.SetActive(Lesson4Completed);
    }

    public void CompletedLesson()
    {
        Lesson4CompletedOnce = true;
        Lesson4Completed = true;
        beforeLesson.SetActive(false);
        afterLesson.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson4Completed = false;
    }

}
