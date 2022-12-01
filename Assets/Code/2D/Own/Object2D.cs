using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2D : MonoBehaviour
{

	public double mass;
	public double airDrag;
	public float initialVelocity = 0;
	public float initialAngle = 0;
	private Vector2 velocity;
	private GravityController2D gravityController;

	void Start()
	{
		gravityController = FindObjectOfType<GravityController2D>();
		float radians = (float) (initialAngle * Math.PI / 180);
		velocity = new Vector2((float)(initialVelocity * Math.Cos(radians) * Math.Sqrt(gravityController.speedMultiplier) / gravityController.distanceMultiplier), (float)(initialVelocity * Math.Sin(radians) * Math.Sqrt(gravityController.speedMultiplier) / gravityController.distanceMultiplier));
		//Debug.Log("Initial: " + velocity.x);
		//Debug.Log("Initial: " + velocity.y);
	}
	
	//Called 50 times per second (0.02)
	void FixedUpdate()
	{
		transform.position += new Vector3(velocity.x/50, velocity.y/50, 0f);
	}

	public void AddVelocity(Vector2 direction)
	{
		velocity += direction;
		//Debug.Log("added x: " + direction.x);
		//Debug.Log("added y: " + direction.y);

	}
}