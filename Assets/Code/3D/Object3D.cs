using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3D : MonoBehaviour
{
	public double mass;
	public double airDrag;
	public float initialVelocity;
	public float initialAngle;
	public float initialDepthAngle;
	public Vector3 velocity;

	private GravityController gravityController;
	private SystemController systemController;

	void Start()
	{
		gravityController = FindObjectOfType<GravityController>();
		systemController = FindObjectOfType<SystemController>();
		float radians = (float) (initialAngle * Mathf.Deg2Rad);
		float radiansDepth = (float)(initialDepthAngle * Mathf.Deg2Rad);
		var initialMuliplier = Math.Sqrt(gravityController.speedMultiplier) / gravityController.distanceMultiplier;

		var xzHyp = initialVelocity * Math.Tan(radians);

		velocity = new Vector3(
			(float)(xzHyp * Math.Cos(radiansDepth) * initialMuliplier), 
			(float)(initialVelocity * Math.Sin(radians) * initialMuliplier),
			(float)(xzHyp * Math.Sin(radiansDepth) * initialMuliplier)
		);
	}
	
	//Called 50 times per second (0.02)
	void FixedUpdate()
	{
		if (systemController.pause)
			return;

		transform.position += new Vector3(velocity.x/50, velocity.y/50, velocity.z/50);
		//Debug.Log(transform.position);
	}

	public void AddVelocity(Vector3 direction)
	{
		velocity += direction;
	}
}