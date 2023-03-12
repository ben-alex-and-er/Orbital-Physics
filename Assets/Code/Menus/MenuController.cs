using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static LessonsCompleted;

public class MenuController : MonoBehaviour
{
    [Header("Ticks")]
    [SerializeField]
    private GameObject basicTick;
    [SerializeField]
    private GameObject binaryTick;
    [SerializeField]
    private GameObject equationsTick;
    [SerializeField]
    private GameObject solarTick;
    [SerializeField]
    private GameObject sandboxTick;
    [SerializeField]
    private GameObject demoTick;

    [Header("Locks")]
    [SerializeField]
    private GameObject binaryLock;
    [SerializeField]
    private GameObject equationsLock;
    [SerializeField]
    private GameObject solarLock;
    [SerializeField]
    private GameObject sandboxLock;

    [Header("Buttons")]
    [SerializeField]
    private Button binaryButton;
    [SerializeField]
    private Button equationsButton;
    [SerializeField]
    private Button solarButton;
    [SerializeField]
    private Button sandboxButton;


    private void Awake()
    {
        basicTick.SetActive(BasicsCompleted);
        binaryTick.SetActive(BinaryCompleted);
        equationsTick.SetActive(EquationsCompleted);
        solarTick.SetActive(SolarCompleted);
        sandboxTick.SetActive(SandboxCompleted);
        demoTick.SetActive(DemoMode);

        binaryLock.SetActive(!BasicsCompleted);
        binaryButton.interactable = (BasicsCompleted);

        equationsLock.SetActive(!BasicsCompleted);
        equationsButton.interactable = (BasicsCompleted);

        solarLock.SetActive(!BasicsCompleted);
        solarButton.interactable = (BasicsCompleted);

        sandboxLock.SetActive(!BasicsCompleted || !EquationsCompleted || !SolarCompleted || !BinaryCompleted);
        sandboxButton.interactable = (BasicsCompleted && EquationsCompleted && SolarCompleted && BinaryCompleted);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DemoButton()
    {
        DemoMode = !DemoMode;

        Lesson1CompletedOnce = DemoMode;
        Lesson2CompletedOnce = DemoMode;
        Lesson3CompletedOnce = DemoMode;
        Lesson4CompletedOnce = DemoMode;
        Lesson5CompletedOnce = DemoMode;
        Lesson6CompletedOnce = DemoMode;
        Lesson7CompletedOnce = DemoMode;
        Lesson8CompletedOnce = DemoMode;
        Lesson9CompletedOnce = DemoMode;
        Lesson10CompletedOnce = DemoMode;
        Lesson11CompletedOnce = DemoMode;
        Lesson12CompletedOnce = DemoMode;

        BasicsCompleted = DemoMode;
        BinaryCompleted = DemoMode;
        EquationsCompleted = DemoMode;
        SolarCompleted = DemoMode;
        SandboxCompleted = DemoMode;

        Awake();
    }
}


