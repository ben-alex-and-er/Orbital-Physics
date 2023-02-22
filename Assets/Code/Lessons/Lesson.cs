using System.Collections.Generic;
using UnityEngine;


public class Lesson : MonoBehaviour
{
    [Header("Lesson Text")]

    [SerializeField]
    protected GameObject part1;
    [SerializeField]
    protected GameObject finalPart;

    protected List<GameObject> objects;

    protected void SetOneActive(GameObject active)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(obj == active);
        }
    }
}
