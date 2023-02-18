using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float zoom;

    // Update is called once per frame
    void Update()
    {
        cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom;
    }
}
