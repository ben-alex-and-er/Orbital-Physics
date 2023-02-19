using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LessonsCompleted;

public class BasicsMenu : MonoBehaviour
{
    [Header("Ticks")]
    [SerializeField]
    private GameObject tick1;
    [SerializeField]
    private GameObject tick2;
    [SerializeField]
    private GameObject tick3;

    [Header("Locks")]
    [SerializeField]
    private GameObject lock2;
    [SerializeField]
    private GameObject lock3;

    [Header("Buttons")]
    [SerializeField]
    private Button button2;
    [SerializeField]
    private Button button3;

    private void Awake()
    {
        tick1.SetActive(Lesson1CompletedOnce);
        tick2.SetActive(Lesson2CompletedOnce);
        tick3.SetActive(Lesson3CompletedOnce);

        lock2.SetActive(!Lesson1CompletedOnce);
        button2.interactable = Lesson1CompletedOnce;

        lock3.SetActive(!Lesson2CompletedOnce);
        button3.interactable = Lesson2CompletedOnce;
    }

    public void LoadScene(string scene)
    {
        if (Lesson1CompletedOnce && Lesson2CompletedOnce && Lesson3CompletedOnce)
            BasicsCompleted = true;

        SceneManager.LoadScene(scene);
    }
}


