using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGravity : MonoBehaviour
{
    protected const double G = 0.00000000006674;
    protected const double minCollisionDistance = 2;
    protected GravityController gravityController;
    protected SystemController systemController;
}
