using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour
{
    private GameObject draggedObject;

    [SerializeField]
    private Object2D selfObject2D;
    [SerializeField]
    private TrailRenderer trail;

    private PlanetEditor planetEditor;
    private SystemController systemController;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        planetEditor = FindObjectOfType<PlanetEditor>();
        systemController = FindObjectOfType<SystemController>();
    }

    void Update()
    {
        if (draggedObject == null || !systemController.pause)
            return;

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = mainCamera.ScreenToWorldPoint(mousePos);
        transform.position = p;
    }

    public void OnMouseDown()
    {
        planetEditor.SetPlanet(selfObject2D, false);

        if (!systemController.pause)
            return;

        draggedObject = gameObject;
        trail.emitting = false;
    }

    public void OnMouseUp()
    {
        if (!systemController.pause)
            return;

        draggedObject = null;

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        List<RaycastResult> results = new();

        PointerEventData pointerEvent = new(EventSystem.current)
        {
            position = mousePos
        };

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
        Destroy(gameObject);
    }
}
