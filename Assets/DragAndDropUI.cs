using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject draggedObject;

    [SerializeField]
    private Vector2 boundaries;
    [SerializeField]
    private GameObject planet;

    private Vector3 start;
    private bool ui;
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedObject = gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggedObject = null;
        if ((transform.position.x > boundaries.x) && (transform.position.y < boundaries.y))
        {
            Debug.Log(transform.position.x + ">" + boundaries.x);
            ToUI();
        }
        else
        {
            ToObject();
        }
    }


    private void ToUI()
    {
        Debug.Log("ui");
        transform.position = start;
    }

    private void ToObject()
    {
        Debug.Log("To Object");
        planet.SetActive(true);

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = camera.ScreenToWorldPoint(mousePos);
        planet.transform.position = p;

        this.gameObject.SetActive(false);
    }
}
