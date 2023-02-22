using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGravity : MonoBehaviour
{
    [SerializeField]
    protected double minCollisionDistance = 2;

    protected const double G = 0.00000000006674;
    protected GravityController gravityController;
    protected SystemController systemController;
}
