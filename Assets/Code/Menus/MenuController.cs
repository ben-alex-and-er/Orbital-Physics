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

        binaryLock.SetActive(!BasicsCompleted);
        binaryButton.interactable = (BasicsCompleted);

        equationsLock.SetActive(!BasicsCompleted);
        equationsButton.interactable = (BasicsCompleted);

        solarLock.SetActive(!BasicsCompleted);
        solarButton.interactable = (BasicsCompleted);

        sandboxLock.SetActive(!BasicsCompleted || !EquationsCompleted || !SolarCompleted || !SandboxCompleted);
        sandboxButton.interactable = (BasicsCompleted && EquationsCompleted && SolarCompleted && SandboxCompleted);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}


