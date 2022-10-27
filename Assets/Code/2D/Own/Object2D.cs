using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2D : MonoBehaviour
{

	public double mass;
	public double airDrag;
	private Vector2 velocity = 0;
	
	//Called 50 times per second (0.02)
	void FixedUpdate()
	{
		transform.position += velocity * 0.02;
		velocity += velocity * 0.02;
	}

	public void AddImpulseForce(Vector2 force)
	{

	}

	public void AddVelocity(Vector2 direction)
	{
		velocity += direction;
	}
}