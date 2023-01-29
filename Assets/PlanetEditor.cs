using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlanetEditor : MonoBehaviour
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

	[Header("InputField")]
	[SerializeField]
	private TMP_InputField massInputField;

	private void Start()
	{
		mass.onValueChanged.AddListener(delegate { MassChange(); });
		initialVelocity.onValueChanged.AddListener(delegate { VelocityChange(); });
		initialAngle.onValueChanged.AddListener(delegate { AngleChange(); });

		massInputField.onValueChanged.AddListener(delegate { MassInputChange(); });
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

	private void MassInputChange()
    {
		Debug.Log(massInputField.text);
		
		planet.mass = int.Parse(massInputField.text);
		
    }
}
