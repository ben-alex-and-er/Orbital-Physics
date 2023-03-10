using UnityEngine;
using UnityEngine.SceneManagement;

public class SandboxMenu : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}


