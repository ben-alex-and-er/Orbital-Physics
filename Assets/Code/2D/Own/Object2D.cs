using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2D : MonoBehaviour
{

	public double mass;
	public double airDrag;
	public float initialVelocity = 0;
    public float angle = 0; 
	private Vector2 velocity;
	private Vector2 acceleration;
	private GravityController2D gravityController;
	private float multiplierConstant;

	void Start()
	{
		gravityController = FindObjectOfType<GravityController2D>();
		velocity = new Vector2((float)(initialVelocity * Math.Cos(angle)), (float)(initialVelocity * Math.Sin(angle)));
		multiplierConstant = 0.02f / gravityController.speedMultiplier / gravityController.distanceMultiplier;
	}
	
	//Called 50 times per second (0.02)
	void FixedUpdate()
	{
		// Debug.Log(velocity.x + " " + multiplierConstant);
		transform.position += new Vector3(
			velocity.x * multiplierConstant,
		 	velocity.y * multiplierConstant,
			0f);
		// transform.position += new Vector3(1,2,3);
		if (velocity.x > 1)
			Debug.Log(transform.position.x + " by " + transform.position.y);
	}

	public void AddVelocity(Vector2 direction)
	{
		velocity += direction;
		// Debug.Log(direction);
	}
}