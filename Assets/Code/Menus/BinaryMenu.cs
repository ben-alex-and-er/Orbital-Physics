using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LessonsCompleted;

public class BinaryMenu : MonoBehaviour
{
    [Header("Lessons")]
    [SerializeField]
    private GameObject tick4;
    [SerializeField]
    private GameObject tick5;
    [SerializeField]
    private GameObject tick6;

    [Header("Locks")]
    [SerializeField]
    private GameObject lock5;
    [SerializeField]
    private GameObject lock6;

    [Header("Buttons")]
    [SerializeField]
    private Button button5;
    [SerializeField]
    private Button button6;


    private void Awake()
    {
        tick4.SetActive(Lesson4CompletedOnce);
        tick5.SetActive(Lesson5CompletedOnce);
        tick6.SetActive(Lesson6CompletedOnce);

        lock5.SetActive(!Lesson4CompletedOnce);
        button5.interactable = Lesson4CompletedOnce;

        lock6.SetActive(!Lesson5CompletedOnce);
        button6.interactable = Lesson5CompletedOnce;
    }

    public void LoadScene(string scene)
    {
        if (Lesson4CompletedOnce && Lesson5CompletedOnce && Lesson6CompletedOnce)
            BinaryCompleted = true;

        SceneManager.LoadScene(scene);
    }
}


