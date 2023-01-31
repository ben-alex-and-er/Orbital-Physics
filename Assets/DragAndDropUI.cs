using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject planet;
    [SerializeField]
    private GridLayoutGroup gridLayout;

    private Camera mainCamera;
    private PlanetEditor planetEditor;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        planetEditor = FindObjectOfType<PlanetEditor>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        List<RaycastResult> results = new();

        PointerEventData pointerEvent = new(EventSystem.current);
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

        var newObject = Instantiate(gameObject);
        newObject.transform.parent = gameObject.transform.parent;
        Destroy(gameObject);
    }

    private void ToObject()
    {
        Debug.Log("To Object");

        var mousePos = Input.mousePosition;
        mousePos.z = 908.9f;

        var p = mainCamera.ScreenToWorldPoint(mousePos);

        var newPlanet = Instantiate(planet); 
        newPlanet.transform.position = p;
        planetEditor.SetPlanet(newPlanet.GetComponent<Object2D>());

        var newObject = Instantiate(gameObject);
        //newObject.transform.parent = gameObject.transform.parent;
        newObject.transform.SetParent(gameObject.transform.parent, false);
        Destroy(gameObject);
    }
}
