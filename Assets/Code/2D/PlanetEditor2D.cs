using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlanetEditor2D : PlanetEditor
{
	[Header("2D")]
	public Object2D planet;

	[SerializeField]
	private Lesson3 lesson3;

	[SerializeField]
	private Lesson10 lesson10;

	[SerializeField]
	private TempCalc tempCalc;

	private bool angleSliderInteractableOnStart;

	private void Start()
	{
		initialMultiplier = Math.Sqrt(gravityController.speedMultiplier * gravityController.timeScale / gravityController.distanceMultiplier);

		if (!disableEditor)
        {
			massInputField.onValueChanged.AddListener(delegate { MassChange(true); });
			massExponential.onValueChanged.AddListener(delegate { MassChange(false); });
			velocityInputField.onValueChanged.AddListener(delegate { VelocityChange(true); });
			velocityExponential.onValueChanged.AddListener(delegate { VelocityChange(false); });
			angleSlider.onValueChanged.AddListener(delegate { AngleChange(); });
        }

		angleSliderInteractableOnStart = angleSlider.interactable;

		if (planet != null)
			planetName.text = planet.gameObject.name;

		if (disableEditor)
			EnableInputs(false);
	}

    private void Update()
    {
		if (paused || planet == null)
			return;

		UpdateEditor();

		if (tempCalc != null)
			UpdateTemp();
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

		var velocity = velocityValue * Mathf.Pow(10, velocityExp);

		planet.velocity = new(
			(float)(Mathf.Cos(angle * Mathf.Deg2Rad) * velocity * initialMultiplier), 
			(float)(Mathf.Sin(angle * Mathf.Deg2Rad) * velocity * initialMultiplier));
	}

	private void AngleChange()
    {
		angle = angleSlider.value;
		VelocityChange(true);
		VelocityChange(false);
		angleText.text = angle.ToString();
        arrow.transform.eulerAngles = new Vector3(0, 0, angle);
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
	}

	public void SetPlanet(Object2D newPlanet, bool newCreation)
    {
		planet = newPlanet;
		planetName.text = planet.gameObject.name;

		UpdateEditor(newCreation);

		if (tempCalc != null)
			tempCalc.planet = newPlanet;
	}

	private void UpdateEditor(bool newPlanet = false)
    {
		massExp = (int)(Math.Floor(Math.Log(planet.mass, 10) + 1) - 1);
		massValue = planet.mass / (Mathf.Pow(10, massExp));
		massValue = MathF.Round((float)massValue * 1000f) / 1000f;

		var planetVelocity = new Vector2(
			(float)(planet.velocity.x / initialMultiplier),
			(float)(planet.velocity.y / initialMultiplier)
		).magnitude;

		if (newPlanet)
        {
			planetVelocity = planet.initialVelocity;
			if (lesson3 != null)
				lesson3.Part2(planet);
        }

		if (lesson10 != null)
			lesson10.CompletedLesson(planet);

		velocityExp = (int)(Math.Floor(Math.Log(planetVelocity, 10) + 1) - 1);
		if (velocityExp == int.MinValue)
			velocityExp = 0;

		velocityValue = planetVelocity / (Mathf.Pow(10, velocityExp));
		velocityValue = MathF.Round((float)velocityValue * 1000f) / 1000f;
		if (double.IsNaN(velocityValue))
			velocityValue = 0;

		var tempAngle = planet.velocity.x != 0 ? Mathf.Rad2Deg * Mathf.Atan(planet.velocity.y / planet.velocity.x) : 90;
		if (float.IsNaN(tempAngle))
			tempAngle =  0;

		bool xPositive = planet.velocity.x > 0;
		bool yPositive = planet.velocity.y > 0;

		if (xPositive && !yPositive)
		{
			tempAngle += 360;
		}
		else if (!xPositive)
		{
			tempAngle += 180;
		}

		angle = planetVelocity == planet.initialVelocity ? planet.initialAngle : tempAngle;

		//Set Values
		massInputField.text = massValue.ToString();
		massExponential.text = massExp.ToString();

		velocityInputField.text = velocityValue.ToString();
		velocityExponential.text = velocityExp.ToString();

		angleSlider.value = angle;
		angleText.text = angle.ToString();

		arrow.transform.eulerAngles = new Vector3(0, 0, angle);
	}

	private void UpdateTemp()
    {

    }
}
