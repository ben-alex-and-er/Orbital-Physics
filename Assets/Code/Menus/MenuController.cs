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
    private GameObject solarTick;
    [SerializeField]
    private GameObject sandboxTick;

    [Header("Locks")]
    [SerializeField]
    private GameObject binaryLock;
    [SerializeField]
    private GameObject solarLock;
    [SerializeField]
    private GameObject sandboxLock;

    [Header("Buttons")]
    [SerializeField]
    private Button binaryButton;
    [SerializeField]
    private Button solarButton;
    [SerializeField]
    private Button sandboxButton;


    private void Awake()
    {
        basicTick.SetActive(BasicsCompleted);
        binaryTick.SetActive(BinaryCompleted);
        solarTick.SetActive(SolarCompleted);
        sandboxTick.SetActive(SandboxCompleted);

        binaryLock.SetActive(!BasicsCompleted);
        binaryButton.interactable = (BasicsCompleted);

        solarLock.SetActive(!BasicsCompleted);
        solarButton.interactable = (BasicsCompleted);

        sandboxLock.SetActive(!BasicsCompleted || !SolarCompleted || !SandboxCompleted);
        sandboxButton.interactable = (BasicsCompleted && SolarCompleted && SandboxCompleted);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}


