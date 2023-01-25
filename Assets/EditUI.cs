using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditUI : MonoBehaviour
{
    [SerializeField]
    private Object2D object2D;
    [SerializeField]
    private InputField mass;
    [SerializeField]
    private InputField initialVelocity;
    [SerializeField]
    private InputField angle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        object2D.mass = double.Parse(mass.text);
    }
}
