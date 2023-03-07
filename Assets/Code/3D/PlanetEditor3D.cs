using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlanetEditor3D : PlanetEditor
{
	public Object3D planet;

	[Header("Depth Angle")]
	[SerializeField]
	private Slider depthAngleSlider;
	[SerializeField]
	private TMP_Text depthAngleText;

	private float depthAngle;
	private bool angleSliderInteractableOnStart;
	private bool depthSliderInteractableOnStart;


	void Start()
	{
		initialMultiplier = Math.Sqrt(gravityController.speedMultiplier * gravityController.timeScale / gravityController.distanceMultiplier);
		
		if (!disableEditor)
        {
			massInputField.onValueChanged.AddListener(delegate { MassChange(true); });
			massExponential.onValueChanged.AddListener(delegate { MassChange(false); });
			velocityInputField.onValueChanged.AddListener(delegate { VelocityChange(true); });
			velocityExponential.onValueChanged.AddListener(delegate { VelocityChange(false); });
			angleSlider.onValueChanged.AddListener(delegate { AngleChange(); });
			depthAngleSlider.onValueChanged.AddListener(delegate { AngleChange(); });
        }

		angleSliderInteractableOnStart = angleSlider.interactable;
		depthSliderInteractableOnStart = depthAngleSlider.interactable;

		if (planet != null)
			planetName.text = planet.gameObject.name;

		if (disableEditor)
			EnableInputs(false);
	}

	void Update()
	{
		if (paused || planet == null)
			return;

		UpdateEditor();
	}

	private void MassChange(bool value)
	{
		if (!paused)
			return;

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
		if (!paused)
			return;

		if (value)
		{
			velocityValue = double.Parse(velocityInputField.text);
		}
		else
		{
			velocityExp = int.Parse(velocityExponential.text);
		}

		var velocity = velocityValue * Mathf.Pow(10, velocityExp);

		var alpha = angle * Mathf.Deg2Rad;
		var beta = depthAngle * Mathf.Deg2Rad;

		planet.velocity = new (
			(float)(velocity * Math.Cos(beta) * Math.Cos(alpha) * initialMultiplier),
			(float)(velocity * Math.Cos(beta) * Math.Sin(alpha) * initialMultiplier),
			(float)(velocity * Math.Sin(beta) * initialMultiplier)
		);

	}

	private void AngleChange()
	{
		if (!paused)
			return;

		angle = angleSlider.value;
		depthAngle = depthAngleSlider.value;
		VelocityChange(true);
		VelocityChange(false);
		angleText.text = angle.ToString();
		depthAngleText.text = depthAngle.ToString();
		arrow.transform.eulerAngles = new Vector3(0, depthAngle, angle);
	}

	public override void OnPause(bool pause)
	{
		if (!disableEditor)
			EnableInputs(pause);

		paused = pause;

		if (pause)
			UpdateEditor();
	}

	private void EnableInputs(bool enable)
	{
		massInputField.enabled = enable;
		massExponential.enabled = enable;
		velocityInputField.enabled = enable;
		velocityExponential.enabled = enable;

		if (angleSliderInteractableOnStart)
			angleSlider.interactable = enable;

		if (depthSliderInteractableOnStart)
			depthAngleSlider.interactable = enable;
	}

	public override void SetPlanet(BaseObject newPlanet, bool newCreation)
	{
		planet = (Object3D)newPlanet;
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
		if (velocityExp == int.MinValue)
			velocityExp = 0;

		velocityValue = planetVelocity / (Mathf.Pow(10, velocityExp));
		velocityValue = MathF.Round((float)velocityValue * 1000f) / 1000f;
		if (double.IsNaN(velocityValue))
			velocityValue = 0;

		var tempAngle = planet.velocity.x != 0 ? Mathf.Rad2Deg * Mathf.Atan(planet.velocity.y / planet.velocity.x) : 90;
		if (float.IsNaN(tempAngle))
			tempAngle = 0;
		
		var tempDepthAngle = planet.velocity.z != 0 ? Mathf.Rad2Deg * Mathf.Atan(planet.velocity.x / planet.velocity.z) : 0;
		if (float.IsNaN(tempDepthAngle))
			tempDepthAngle = 0;

		bool xPositive = planet.velocity.x >= 0;
		bool yPositive = planet.velocity.y >= 0; 
		bool zPositive = planet.velocity.z >= 0;

		if (xPositive && !yPositive)
		{
			tempAngle += 360;
		}
		else if (!xPositive)
		{
			tempAngle += 180;
		}

		if (zPositive && !xPositive)
        {
			tempDepthAngle += 360;
        }
		else if (!zPositive)
        {
			tempDepthAngle += 180;
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

		angleText.text = angle.ToString();
		depthAngleText.text = depthAngle.ToString();
		arrow.transform.eulerAngles = new Vector3(0, depthAngle, angle);
	}
}
