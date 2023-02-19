using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tabs;

    public void ClickTab(GameObject clickedTab)
    {
        foreach (GameObject tab in tabs)
        {
            tab.SetActive(tab == clickedTab);
        }
    }
}
