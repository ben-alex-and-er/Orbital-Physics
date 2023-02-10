using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity3D : BaseGravity
{
    public List<Object3D> gravityObjects = new();

    [SerializeField]
    private Object3D object3D;

    // Start is called before the first frame update
    void Start()
    {
        gravityController = FindObjectOfType<GravityController>();
        systemController = FindObjectOfType<SystemController>();
        object3D = GetComponent<Object3D>();
        var objs = FindObjectsOfType<Object3D>();
        foreach (Object3D obj in objs)
        {
            if (obj != object3D)
            {
                if (!gravityObjects.Contains(obj))
                    gravityObjects.Add(obj);

                var objGrav = obj.GetComponent<Gravity3D>();
                if (!objGrav.gravityObjects.Contains(object3D))
                    objGrav.gravityObjects.Add(object3D);
            }
        }
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        if (systemController.pause)
            return;

        foreach (Object3D obj in gravityObjects)
        {
            if (obj != object3D && obj != null)
            {
                var acceleration = CalculateAcceleration(obj.gameObject);
                object3D.AddVelocity(acceleration / 50); // As called 50 times per second
            }
        }
    }

    Vector3 CalculateAcceleration(GameObject obj)
    {
        var objPosition = obj.transform.position;

        var xDiff = objPosition.x - transform.position.x;
        var yDiff = objPosition.y - transform.position.y;
        var zDiff = objPosition.z - transform.position.z;

        var hypotenuse = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 2));
        var literalDist = hypotenuse * gravityController.distanceMultiplier;

        var otherObject3d = obj.GetComponent<Object3D>();
        var literalAcc = G * otherObject3d.mass / Math.Pow(literalDist, 2);

        var acceleration = literalAcc * gravityController.speedMultiplier;

        return new Vector3((float)(xDiff * acceleration / hypotenuse), (float)(yDiff * acceleration / hypotenuse), (float)(zDiff * acceleration / hypotenuse));
    }

}
