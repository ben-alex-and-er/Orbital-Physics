using System;
using UnityEngine;

public class Object2D : BaseObject
{
	public Vector2 velocity;

	void Start()
	{
		gravityController = FindObjectOfType<GravityController>();

		float radians = (float) (initialAngle * Mathf.Deg2Rad);

		var initialMultiplier = Math.Sqrt(gravityController.speedMultiplier * gravityController.timeScale / gravityController.distanceMultiplier);

		velocity = new Vector2(
			(float)(initialVelocity * Math.Cos(radians) * initialMultiplier), 
			(float)(initialVelocity * Math.Sin(radians) * initialMultiplier)
		);
	}

	public override void AddVelocity(Vector3 direction)
	{
		velocity += (Vector2) direction;

		transform.position += new Vector3(
			velocity.x / (50 * gravityController.timeScale),
			velocity.y / (50 * gravityController.timeScale),
			0f
		);
	}
}