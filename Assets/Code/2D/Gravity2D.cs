using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity2D : BaseGravity
{
    public List<Object2D> gravityObjects = new();

    [SerializeField]
    private Object2D object2D;

    // Start is called before the first frame update
    void Start()
    {
        gravityController = FindObjectOfType<GravityController>();
        systemController = FindObjectOfType<SystemController>();
        object2D = GetComponent<Object2D>();
        var objs = FindObjectsOfType<Object2D>();
        foreach (Object2D obj in objs)
        {
            if (obj != object2D)
            {
                if (!gravityObjects.Contains(obj))
                    gravityObjects.Add(obj);

                var objGrav = obj.GetComponent<Gravity2D>();
                if (!objGrav.gravityObjects.Contains(object2D))
                    objGrav.gravityObjects.Add(object2D);
            }
        }
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        if (systemController.pause)
            return;

        foreach (Object2D obj in gravityObjects)
        {
            if (obj != object2D && obj != null)
            {
                var acceleration = CalculateAcceleration(obj.gameObject);
                object2D.AddVelocity(acceleration / 50); // As called 50 times per second
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

        var otherObject2d = obj.GetComponent<Object2D>();
        var literalAcc = G * otherObject2d.mass / Math.Pow(literalDist, 2);

        var acceleration = literalAcc * gravityController.speedMultiplier;

        //Debug.Log(gameObject.name + " to " + obj.name + ": " + acceleration);

        return new Vector2((float)(xDiff * acceleration / hypotenuse), (float)(yDiff * acceleration / hypotenuse));
    }

}
