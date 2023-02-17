using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static LessonsCompleted;

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
        if (binaryTick != null) { binaryTick.SetActive(BinaryCompleted); }
        if (solarTick != null) { solarTick.SetActive(SolarCompleted); }
        if (sandboxTick != null) { sandboxTick.SetActive(SandboxCompleted); }

        if (binary2DTick != null) { binary2DTick.SetActive(Binary2D); }
        if (binary3DTick != null) { binary3DTick.SetActive(Binary3D); }

        if (solar2DTick != null) { solar2DTick.SetActive(Solar2D); }
        if (solar3DTick != null) { solar3DTick.SetActive(Solar3D); }

        if (sandbox2DTick != null) { sandbox2DTick.SetActive(Sandbox2D); }
        if (sandbox3DTick != null) { sandbox3DTick.SetActive(Sandbox3D); }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadBinary(bool isTwoD)
    {
        if (isTwoD)
        {
            Binary2D = true;

            if (Binary3D)
            {
                BinaryCompleted = true;
            }
        }
        else
        {
            Binary3D = true;

            if (Binary2D)
            {
                BinaryCompleted = true;
            }
        }
    }

    public void LoadSolar(bool isTwoD)
    {
        if (isTwoD)
        {
            Solar2D = true;

            if (Solar3D)
            {
                SolarCompleted = true;
            }
        }
        else
        {
            Solar3D = true;

            if (Solar2D)
            {
                SolarCompleted = true;
            }
        }
    }

    public void LoadSandbox(bool isTwoD)
    {
        if (isTwoD)
        {
            Sandbox2D = true;

            if (Sandbox3D)
            {
                SandboxCompleted = true;
            }
        }
        else
        {
            Sandbox3D = true;

            if (Sandbox2D)
            {
                SandboxCompleted = true;
            }
        }
    }
}


