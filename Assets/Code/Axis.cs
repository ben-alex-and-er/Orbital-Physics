using UnityEngine;

public class Axis : MonoBehaviour
{
    [SerializeField]
    private GameObject axis;
    [SerializeField]
    private GameObject tick;

    private bool active;

    public void EnableAxis()
    {
        active = !active;
        tick.SetActive(active);
        axis.SetActive(active);
    }
}
