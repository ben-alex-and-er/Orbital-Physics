using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject planet;

    private Camera mainCamera;
    private PlanetEditor2D planetEditor;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        planetEditor = FindObjectOfType<PlanetEditor2D>();
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

        //Create Planet
        var newPlanet = Instantiate(planet); 
        newPlanet.transform.position = p;
        newPlanet.name = planet.name;
        planetEditor.SetPlanet(newPlanet.GetComponent<Object2D>(), true);
        
        //Replace UI Element
        var newObject = Instantiate(gameObject);
        newObject.transform.SetParent(gameObject.transform.parent, false);
        Destroy(gameObject);
    }
}
