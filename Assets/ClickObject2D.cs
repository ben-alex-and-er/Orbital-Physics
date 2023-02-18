using UnityEngine;

public class ClickObject2D : MonoBehaviour
{
    [SerializeField]
    private PlanetEditor2D planetEditor;

    [SerializeField]
    private Object2D selfObject;

    public void OnMouseDown()
    {
        planetEditor.SetPlanet(selfObject, false);
    }
}
