using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static StaticTicks;

public class MenuController : MonoBehaviour
{
    [Header("Main menu")]
    [SerializeField]
    private GameObject binaryTick;
    [SerializeField]
    private GameObject solarTick;
    [SerializeField]
    private GameObject sandboxTick;

    [Header("Binary")]
    [SerializeField]
    private GameObject binary2DTick;
    [SerializeField]
    private GameObject binary3DTick;

    [Header("Solar")]
    [SerializeField]
    private GameObject solar2DTick;
    [SerializeField]
    private GameObject solar3DTick;

    [Header("Sandbox")]
    [SerializeField]
    private GameObject sandbox2DTick;
    [SerializeField]
    private GameObject sandbox3DTick;

    private void Awake()
    {
        if (binaryTick != null) { binaryTick.SetActive(binaryCompleted); }
        if (solarTick != null) { solarTick.SetActive(solarCompleted); }
        if (sandboxTick != null) { sandboxTick.SetActive(sandboxCompleted); }

        if (binary2DTick != null) { binary2DTick.SetActive(binary2D); }
        if (binary3DTick != null) { binary3DTick.SetActive(binary3D); }

        if (solar2DTick != null) { solar2DTick.SetActive(solar2D); }
        if (solar3DTick != null) { solar3DTick.SetActive(solar3D); }

        if (sandbox2DTick != null) { sandbox2DTick.SetActive(sandbox2D); }
        if (sandbox3DTick != null) { sandbox3DTick.SetActive(sandbox3D); }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadBinary(bool isTwoD)
    {
        if (isTwoD)
        {
            binary2D = true;

            if (binary3D)
            {
                binaryCompleted = true;
            }
        }
        else
        {
            binary3D = true;

            if (binary2D)
            {
                binaryCompleted = true;
            }
        }
    }

    public void LoadSolar(bool isTwoD)
    {
        if (isTwoD)
        {
            solar2D = true;

            if (solar3D)
            {
                solarCompleted = true;
            }
        }
        else
        {
            solar3D = true;

            if (solar2D)
            {
                solarCompleted = true;
            }
        }
    }

    public void LoadSandbox(bool isTwoD)
    {
        if (isTwoD)
        {
            sandbox2D = true;

            if (sandbox3D)
            {
                sandboxCompleted = true;
            }
        }
        else
        {
            sandbox3D = true;

            if (sandbox2D)
            {
                sandboxCompleted = true;
            }
        }
    }
}


