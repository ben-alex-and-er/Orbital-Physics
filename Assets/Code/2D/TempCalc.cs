using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempCalc : MonoBehaviour
{
    [SerializeField]
    private GravityController gravityController;

    [Header("Objects")]
    public Object2D planet;

    [SerializeField]
    private Object2D star;

    [Header("Values")]
    [SerializeField]
    private float starTemp = 5778;

    [SerializeField]
    private float starRadius = 696340000;

    [Header("Text")]
    [SerializeField]
    private TMP_Text kValue;

    [SerializeField]
    private TMP_Text cValue;

    private const float CToK = 273.15f;

    void Update()
    {
        var xDiff = star.transform.position.x - planet.transform.position.x;
        var yDiff = star.transform.position.y - planet.transform.position.y;
        var hypotenuse = Mathf.Sqrt(Mathf.Pow(xDiff, 2) + Mathf.Pow(yDiff, 2));
        var distance = hypotenuse * gravityController.distanceMultiplier;

        var t = starTemp * Mathf.Sqrt(starRadius / (2 * distance));

        kValue.text = ((int)Math.Round(t, 0)).ToString();
        cValue.text = ((int)Math.Round(t - CToK, 0)).ToString();
    }
}
