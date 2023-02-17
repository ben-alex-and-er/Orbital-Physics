using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemController : MonoBehaviour
{
    [HideInInspector]
    public bool pause = true;

    [SerializeField]
    private PlanetEditor planetEditor;
    [SerializeField]
    private GameObject dragAndDrop;

    public void PlayPause()
    {
        pause = !pause;
        if (planetEditor != null)
            planetEditor.OnPause(pause);

        if (dragAndDrop != null)
            dragAndDrop.SetActive(pause);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
