using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
	[SerializeField]
	private Object2D planet;

	[Header("Sliders")]

	[SerializeField]
	private Slider mass;
	[SerializeField]
	private Slider initialVelocity;
	[SerializeField]
	private Slider initialAngle;

	private void Start()
	{
		mass.onValueChanged.AddListener(delegate { MassChange(); });
		initialVelocity.onValueChanged.AddListener(delegate { VelocityChange(); });
		initialAngle.onValueChanged.AddListener(delegate { AngleChange(); });
	}

	private void MassChange()
	{
		Debug.Log(mass.value);
		planet.mass = mass.value;
	}

	private void VelocityChange()
	{
		Debug.Log(initialVelocity.value);
		planet.initialVelocity = initialVelocity.value;
	}

	private void AngleChange()
	{
		Debug.Log(initialAngle.value);
		planet.initialAngle = initialAngle.value;
	}
}
