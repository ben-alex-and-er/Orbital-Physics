using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity2D : MonoBehaviour
{

    public List<GameObject> gravityObjects;
    public double initialVelocity = 0;
    public double angle = 0; 
    private double G = 0.00000000006674;
    private double Gtemp = 0.1;
    private Object2D object2D;

    // Start is called before the first frame update
    void Start()
    {
        object2D = GetComponent<Object2D>();
        // object2D.AddImpulseForce(new Vector2((float) (initialVelocity * Math.Cos(angle)), (float) (initialVelocity * Math.Sin(angle))));
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        foreach(GameObject obj in gravityObjects)
        {
            var acceleration = CalculateAcceleration(obj);
            object2D.AddVelocity(acceleration);
        }
        Debug.Log(transform.position);
    }

    Vector2 CalculateAcceleration(GameObject obj)
    {
        var objPosition = obj.transform.position;
        var xDiff = objPosition.x - transform.position.x;
        var yDiff = objPosition.y - transform.position.y;
        var hypotenuse = Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2);
        var objRigidbody = obj.GetComponent<Rigidbody2D>();
        var acceleration = Gtemp * objRigidbody.mass / hypotenuse;
        var ratio = acceleration / hypotenuse;
        return new Vector2((float)(xDiff * ratio), (float)(yDiff * ratio));
    }

}
