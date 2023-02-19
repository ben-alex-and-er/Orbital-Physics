using static LessonsCompleted;

public class Lesson1 : Lesson
{
    // Play/Pause usage

    private void Start()
    {
        beforeLesson.SetActive(!Lesson1Completed);
        afterLesson.SetActive(Lesson1Completed);
    }

    public void CompletedLesson()
    {
        Lesson1CompletedOnce = true;
        Lesson1Completed = true;
        beforeLesson.SetActive(false);
        afterLesson.SetActive(true);
    }

    public void ResetLesson()
    {
        Lesson1Completed = false;
    }

}
