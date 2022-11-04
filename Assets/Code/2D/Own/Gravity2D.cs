using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity2D : MonoBehaviour
{

    private List<Object2D> gravityObjects = new List<Object2D>();
    private double G = 0.00000000006674;
    private double Gtemp = 0.000001;
    private Object2D object2D;

    // Start is called before the first frame update
    void Start()
    {
        object2D = GetComponent<Object2D>();
        var objs = FindObjectsOfType<Object2D>();
        foreach (Object2D obj in objs)
        {
            if (obj != object2D)
            {
                gravityObjects.Add(obj);
            }
        }
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        foreach(Object2D obj in gravityObjects)
        {
            if (obj != object2D)
            {
                var acceleration = CalculateAcceleration(obj.gameObject);
                object2D.AddVelocity(acceleration);
            }
        }
    }

    Vector2 CalculateAcceleration(GameObject obj)
    {
        var objPosition = obj.transform.position;
        var xDiff = objPosition.x - transform.position.x;
        var yDiff = objPosition.y - transform.position.y;
        var hypotenuse = Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2);
        var otherObject2d = obj.GetComponent<Object2D>();
        var acceleration = G * otherObject2d.mass / hypotenuse;
        var ratio = acceleration / hypotenuse;
        return new Vector2((float)(xDiff * ratio), (float)(yDiff * ratio));
    }

}
