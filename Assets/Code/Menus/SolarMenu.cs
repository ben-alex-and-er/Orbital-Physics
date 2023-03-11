using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LessonsCompleted;

public class SolarMenu : MonoBehaviour
{
    [Header("Lessons")]
    [SerializeField]
    private GameObject tick10;
    [SerializeField]
    private GameObject tick11;
    [SerializeField]
    private GameObject tick12;

    [Header("Locks")]
    [SerializeField]
    private GameObject lock11;
    [SerializeField]
    private GameObject lock12;

    [Header("Buttons")]
    [SerializeField]
    private Button button11;
    [SerializeField]
    private Button button12;


    private void Awake()
    {
        tick10.SetActive(Lesson10CompletedOnce);
        tick11.SetActive(Lesson11CompletedOnce);
        tick12.SetActive(Lesson12CompletedOnce);

        lock11.SetActive(!Lesson10CompletedOnce);
        button11.interactable = Lesson10CompletedOnce;

        lock12.SetActive(!Lesson11CompletedOnce);
        button12.interactable = Lesson11CompletedOnce;
    }

    public void LoadScene(string scene)
    {
        if (Lesson10CompletedOnce && Lesson11CompletedOnce && Lesson12CompletedOnce)
            SolarCompleted = true;

        SceneManager.LoadScene(scene);
    }
}


