using UnityEngine;

public abstract class BaseObject : MonoBehaviour
{
	public double mass;
	public float initialVelocity;
	public float initialAngle;

    protected GravityController gravityController;

	public abstract void AddVelocity(Vector3 vector3);
}