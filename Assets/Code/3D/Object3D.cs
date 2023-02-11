using System;
using UnityEngine;

public class Object3D : BaseObject
{
	public float initialDepthAngle;
	public Vector3 velocity;

	void Start()
	{
		gravityController = FindObjectOfType<GravityController>();

		float radians = (float) (initialAngle * Mathf.Deg2Rad);
		float radiansDepth = (float)(initialDepthAngle * Mathf.Deg2Rad);

		var initialMultiplier = Math.Sqrt(gravityController.speedMultiplier * gravityController.timeScale / gravityController.distanceMultiplier);

		velocity = new Vector3(
			(float)(initialVelocity * Math.Cos(radiansDepth) * Math.Cos(radians) * initialMultiplier),
			(float)(initialVelocity * Math.Cos(radiansDepth) * Math.Sin(radians) * initialMultiplier),
			(float)(initialVelocity * Math.Sin(radiansDepth) * initialMultiplier)
		);
	}
	
	public override void AddVelocity(Vector3 direction)
	{
		velocity += direction;

		transform.position += new Vector3(
			velocity.x / (50 * gravityController.timeScale),
			velocity.y / (50 * gravityController.timeScale),
			velocity.z / (50 * gravityController.timeScale)
		);
	}
}