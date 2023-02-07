using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2D : MonoBehaviour
{
	public double mass;
	public double airDrag;
	public float initialVelocity;
	public float initialAngle;
	public Vector2 velocity;

	private GravityController gravityController;
	private SystemController systemController;

	void Start()
	{
		gravityController = FindObjectOfType<GravityController>();
		systemController = FindObjectOfType<SystemController>();
		float radians = (float) (initialAngle * Math.PI / 180);
		var initialMuliplier = Math.Sqrt(gravityController.speedMultiplier) / gravityController.distanceMultiplier;
		velocity = new Vector2(
			(float)(initialVelocity * Math.Cos(radians) * initialMuliplier), 
			(float)(initialVelocity * Math.Sin(radians) * initialMuliplier)
		);
	}
	
	//Called 50 times per second (0.02)
	void FixedUpdate()
	{
		if (systemController.pause)
			return;

		transform.position += new Vector3(velocity.x/50, velocity.y/50, 0f);
		//Debug.Log(transform.position);
	}

	public void AddVelocity(Vector2 direction)
	{
		velocity += direction;
	}
}