using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
	public float speedMultiplier = 166.666f;
	public float distanceMultiplier = 1000000000;
    public float timeScale = 60;

    void Start()
    {
        Time.timeScale = timeScale;
    }
}
