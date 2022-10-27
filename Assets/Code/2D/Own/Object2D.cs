using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2D : MonoBehaviour
{

	public double mass;
	public double airDrag;
	private Vector2 velocity;
	private Vector2 acceleration;

	void Start()
	{
		velocity = new Vector2(0,0);
	}
	
	//Called 50 times per second (0.02)
	void FixedUpdate()
	{
		velocity += new Vector2(acceleration.x * 0.02f, acceleration.y * 0.02f);
		transform.position += new Vector3(velocity.x * 0.02f, velocity.y * 0.02f, 0f);
	}

	public void AddVelocity(Vector2 direction)
	{
		velocity += direction;
	}

	public void AddAcceleration(Vector2 accel)
	{
		acceleration += accel;
	}
}