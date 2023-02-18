using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float zoom = 15;
    [SerializeField]
    private float minField = 10;
    [SerializeField]
    private float maxField = 160;

    // Update is called once per frame
    void Update()
    {
        var newField = cam.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * zoom;

        if (newField < maxField && newField > minField)
            cam.fieldOfView = newField;
    }
}
