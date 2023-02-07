using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlanetEditor3D : PlanetEditor
{
	[SerializeField]
	public Object3D planet;
	[SerializeField]
	public TMP_Text planetName;
	[SerializeField]
	private GravityController gravityController;
	[SerializeField]
	private SystemController systemController;

	[Header("Mass")]

	[SerializeField]
	private TMP_InputField massInputField;
	[SerializeField]
	private TMP_InputField massExponential;

	[Header("Velocity")]

	[SerializeField]
	private TMP_InputField velocityInputField;
	[SerializeField]
	private TMP_InputField velocityExponential;

	[Header("Angle")]
	[SerializeField]
	private Slider angleSlider;
	[SerializeField]
	private TMP_Text angleText;
	[SerializeField]
	private GameObject arrow;

	[Header("Depth Angle")]
	[SerializeField]
	private Slider depthAngleSlider;
	[SerializeField]
	private TMP_Text depthAngleText;

	private double massValue;
	private int massExp = 1;
	private double velocityValue;
	private int velocityExp = 1;
	private float angle;
	private float depthAngle;
	private double initialMultiplier;
	private bool paused;

	private void Start()
	{
		initialMultiplier = Math.Sqrt(gravityController.speedMultiplier) / gravityController.distanceMultiplier;

		massInputField.onValueChanged.AddListener(delegate { MassChange(true); });
		massExponential.onValueChanged.AddListener(delegate { MassChange(false); });
		velocityInputField.onValueChanged.AddListener(delegate { VelocityChange(true); });
		velocityExponential.onValueChanged.AddListener(delegate { VelocityChange(false); });
		angleSlider.onValueChanged.AddListener(delegate { AngleChange(); });
		depthAngleSlider.onValueChanged.AddListener(delegate { AngleChange(); });

		SetPlanet(planet, true);
	}

	private void Update()
	{
		if (paused || planet == null)
			return;

		UpdateEditor();
	}

	private void MassChange(bool value)
	{
		if (value)
		{
			massValue = double.Parse(massInputField.text);
		}
		else
		{
			massExp = int.Parse(massExponential.text);
		}

		planet.mass = massValue * Mathf.Pow(10, massExp);
	}

	private void VelocityChange(bool value)
	{
		if (value)
		{
			velocityValue = double.Parse(velocityInputField.text);
		}
		else
		{
			velocityExp = int.Parse(velocityExponential.text);
		}

		var v = velocityValue * Mathf.Pow(10, velocityExp);

		var xzHyp = v * Math.Tan(angle * Mathf.Deg2Rad);

		planet.velocity = new Vector3(
			(float)(xzHyp * Math.Cos(depthAngle * Mathf.Deg2Rad) * initialMultiplier),
			(float)(v * Math.Sin(angle * Mathf.Deg2Rad) * initialMultiplier),
			(float)(xzHyp * Math.Sin(depthAngle * Mathf.Deg2Rad) * initialMultiplier)
		);

		//planet.velocity = new((float)(Mathf.Cos(angle * Mathf.PI / 180) * v * initialMultiplier), (float)(Mathf.Sin(angle * Mathf.PI / 180) * v * initialMultiplier));
	}

	private void AngleChange()
	{
		angle = angleSlider.value;
		depthAngle = depthAngleSlider.value;
		VelocityChange(true);
		VelocityChange(false);
		angleText.text = angle.ToString();
		arrow.transform.eulerAngles = new Vector3(0, depthAngle, angle);
	}

	public override void OnPause(bool pause)
	{
		massInputField.enabled = pause;
		massExponential.enabled = pause;
		velocityInputField.enabled = pause;
		velocityExponential.enabled = pause;
		angleSlider.enabled = pause;
		paused = pause;

		if (pause)
		{
			UpdateEditor();
		}
	}

	public void SetPlanet(Object3D newPlanet, bool newCreation)
	{
		planet = newPlanet;
		planetName.text = planet.name;

		UpdateEditor(newCreation);
	}

	private void UpdateEditor(bool newPlanet = false)
	{
		massExp = (int)(Math.Floor(Math.Log(planet.mass, 10) + 1) - 1);
		massValue = planet.mass / (Mathf.Pow(10, massExp));
		massValue = MathF.Round((float)massValue * 1000f) / 1000f;

		var planetVelocity = new Vector3(
			(float)(planet.velocity.x / initialMultiplier), 
			(float)(planet.velocity.y / initialMultiplier),
			(float)(planet.velocity.z / initialMultiplier)
		).magnitude;

		if (newPlanet)
			planetVelocity = planet.initialVelocity;

		velocityExp = (int)(Math.Floor(Math.Log(planetVelocity, 10) + 1) - 1);
		velocityValue = planetVelocity / (Mathf.Pow(10, velocityExp));
		velocityValue = MathF.Round((float)velocityValue * 1000f) / 1000f;

		var tempAngle = planet.velocity.x != 0 ? Mathf.Rad2Deg * Mathf.Atan(planet.velocity.y / planet.velocity.x) : 0;
		var tempDepthAngle = planet.velocity.z != 0 ? Mathf.Rad2Deg * Mathf.Atan(planet.velocity.x / planet.velocity.z) : 0;

		bool xPositive = planet.velocity.x >= 0;
		bool yPositive = planet.velocity.y >= 0;

		if (xPositive && !yPositive)
		{
			tempAngle += 360;
		}
		else if (!xPositive)
		{
			tempAngle += 180;
		}

		angle = planetVelocity == planet.initialVelocity ? planet.initialAngle : tempAngle;
		depthAngle = planetVelocity == planet.initialVelocity ? planet.initialDepthAngle : tempDepthAngle;

		//Set Values
		massInputField.text = massValue.ToString();
		massExponential.text = massExp.ToString();

		velocityInputField.text = velocityValue.ToString();
		velocityExponential.text = velocityExp.ToString();

		angleSlider.value = angle;
		depthAngleSlider.value = depthAngle;
	}
}
