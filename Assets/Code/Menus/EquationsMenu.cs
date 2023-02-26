using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LessonsCompleted;

public class EquationsMenu : MonoBehaviour
{
    [Header("Lessons")]
    [SerializeField]
    private GameObject tick7;
    [SerializeField]
    private GameObject tick8;
    [SerializeField]
    private GameObject tick9;

    [Header("Locks")]
    [SerializeField]
    private GameObject lock8;
    [SerializeField]
    private GameObject lock9;

    [Header("Buttons")]
    [SerializeField]
    private Button button8;
    [SerializeField]
    private Button button9;


    private void Awake()
    {
        tick7.SetActive(Lesson7CompletedOnce);
        tick8.SetActive(Lesson8CompletedOnce);
        tick9.SetActive(Lesson9CompletedOnce);

        lock8.SetActive(!Lesson7CompletedOnce);
        button8.interactable = Lesson7CompletedOnce;

        lock9.SetActive(!Lesson8CompletedOnce);
        button9.interactable = Lesson8CompletedOnce;
    }

    public void LoadScene(string scene)
    {
        if (Lesson7CompletedOnce && Lesson8CompletedOnce && Lesson9CompletedOnce)
            BinaryCompleted = true;

        SceneManager.LoadScene(scene);
    }
}


