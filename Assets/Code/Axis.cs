using UnityEngine;

public class Axis : MonoBehaviour
{
    [SerializeField]
    private GameObject axis;
    [SerializeField]
    private GameObject tick;

    private bool active = true;

    public void EnableAxis()
    {
        active = !active;
        tick.SetActive(active);
        axis.SetActive(active);
    }
}
