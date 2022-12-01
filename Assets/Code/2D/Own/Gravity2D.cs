using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity2D : MonoBehaviour
{
    private List<Object2D> gravityObjects = new List<Object2D>();
    private double G = 0.00000000006674;
    private Object2D object2D;
    private GravityController2D gravityController;

    // Start is called before the first frame update
    void Start()
    {
        gravityController = FindObjectOfType<GravityController2D>();
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
        foreach (Object2D obj in gravityObjects)
        {
            if (obj != object2D)
            {
                var acceleration = CalculateAcceleration(obj.gameObject);
                object2D.AddVelocity(acceleration / 50);
            }
        }
    }

    Vector2 CalculateAcceleration(GameObject obj)
    {
        var objPosition = obj.transform.position;

        var xDiff = objPosition.x - transform.position.x;
        var yDiff = objPosition.y - transform.position.y;

        var hypotenuse = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2));
        var literalDist = hypotenuse * gravityController.distanceMultiplier;
        //Debug.Log("Distance: " + literalDist);

        var otherObject2d = obj.GetComponent<Object2D>();
        var literalAcc = G * otherObject2d.mass / Math.Pow(literalDist, 2);
        //Debug.Log("Acc: " + literalAcc);

        var acceleration = literalAcc * gravityController.speedMultiplier;

        return new Vector2((float)(xDiff * acceleration / hypotenuse), (float)(yDiff * acceleration / hypotenuse));
    }

}
