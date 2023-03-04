using UnityEngine;

public class ClickObject3D : MonoBehaviour
{
    [SerializeField]
    private PlanetEditor3D planetEditor;

    [SerializeField]
    private Object3D selfObject;

    public void OnMouseDown()
    {
        planetEditor.SetPlanet(selfObject, false);
    }
}
