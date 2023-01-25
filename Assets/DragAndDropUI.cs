using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject draggedObject;

    [SerializeField]
    private GameObject planet;
    [SerializeField]
    private TrailRenderer planetTrail;

    private Vector3 start;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag begin");
        draggedObject = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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

    private void ToUI()
    {
        Debug.Log("To UI");
        transform.position = start;
    }

    private void ToObject()
    {
        Debug.Log("To Object");

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = mainCamera.ScreenToWorldPoint(mousePos);
        planet.transform.position = p;
        planetTrail.emitting = true;
        planet.SetActive(true);

        transform.position = start;
        this.gameObject.SetActive(false);
    }
}
