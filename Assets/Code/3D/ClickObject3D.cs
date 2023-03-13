using UnityEngine;

public class ClickObject3D : MonoBehaviour
{
    [SerializeField]
    private Object3D selfObject;

    private PlanetEditor3D planetEditor;

    private void Start()
    {
        planetEditor = FindObjectOfType<PlanetEditor3D>();
    }
    public void OnMouseDown()
    {
        planetEditor.SetPlanet(selfObject, false);
    }
}
