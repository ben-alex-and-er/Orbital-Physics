using System.Collections;
using System.Collections.Generic;
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
        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
        else
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
    }
}
