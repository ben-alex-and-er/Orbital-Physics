using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset;

    private Camera camera;
    private bool dragging;
    private TrailRenderer trail;
    private SystemController systemController;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        trail = GetComponent<TrailRenderer>();
        systemController = FindObjectOfType<SystemController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dragging)
            return;

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = camera.ScreenToWorldPoint(mousePos);
        transform.position = p;
        Debug.Log(transform.position);
    }

    void OnMouseDown()
    {
        if (!systemController.pause)
            return;

        dragging = true;
        trail.emitting = false;
    }

    void OnMouseUp()
    {
        if (!systemController.pause)
            return;

        dragging = false;
        trail.emitting = true;
    }
}
