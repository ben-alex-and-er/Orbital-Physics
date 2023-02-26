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

    [SerializeField]
    private Lesson10 lesson10;
    [SerializeField]
    private float gasGiantsZoomFOV = 65;

    // Update is called once per frame
    void Update()
    {
        var newField = cam.fieldOfView - Input.GetAxis("Mouse ScrollWheel") * zoom;

        if (lesson10 != null && cam.fieldOfView > gasGiantsZoomFOV)
            lesson10.Part2();

        if (newField < maxField && newField > minField)
            cam.fieldOfView = newField;
    }
}
