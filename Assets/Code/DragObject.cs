using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    private GameObject draggedObject;

    [SerializeField]
    private GameObject uIPlanet;

    private Vector3 start;
    private Camera mainCamera;
    private TrailRenderer trail;
    private SystemController systemController;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        mainCamera = Camera.main;
        trail = GetComponent<TrailRenderer>();
        systemController = FindObjectOfType<SystemController>();
    }

    void Update()
    {
        if (draggedObject == null)
            return;

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = mainCamera.ScreenToWorldPoint(mousePos);
        transform.position = p;
    }

    public void OnMouseDown()
    {
        draggedObject = gameObject;
        trail.emitting = false;
    }

    public void OnMouseUp()
    {
        draggedObject = null;

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = mainCamera.ScreenToWorldPoint(mousePos);

        List<RaycastResult> results = new List<RaycastResult>();

        PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
        pointerEvent.position = mousePos;

        EventSystem.current.RaycastAll(pointerEvent, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag("DragAndDrop"))
            {
                ToUI();
                return;
            }
        }
        ToObject();
    }

    private void ToObject()
    {
        Debug.Log("To Object");
        trail.emitting = true;
    }

    private void ToUI()
    {
        Debug.Log("To UI");
        trail.emitting = false;

        uIPlanet.SetActive(true);

        transform.position = start;
        this.gameObject.SetActive(false);
    }
}
