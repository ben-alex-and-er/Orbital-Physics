using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlanetEditor2D : PlanetEditor
{
	[SerializeField]
	public Object2D planet;
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

	private double massValue;
	private int massExp = 1;
	private double velocityValue;
	private int velocityExp = 1;
	private float angle;
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
		planet.velocity = new((float)(Mathf.Cos(angle * Mathf.Deg2Rad) * v * initialMultiplier), (float)(Mathf.Sin(angle * Mathf.Deg2Rad) * v * initialMultiplier));
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

	public void SetPlanet(Object2D newPlanet, bool newCreation)
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

		var planetVelocity = new Vector2((float)(planet.velocity.x / initialMultiplier), (float)(planet.velocity.y / initialMultiplier)).magnitude;

		if (newPlanet)
			planetVelocity = planet.initialVelocity;

		velocityExp = (int)(Math.Floor(Math.Log(planetVelocity, 10) + 1) - 1);
		velocityValue = planetVelocity / (Mathf.Pow(10, velocityExp));
		velocityValue = MathF.Round((float)velocityValue * 1000f) / 1000f;

		var tempAngle = planet.velocity.x != 0 ? Mathf.Rad2Deg * Mathf.Atan(planet.velocity.y / planet.velocity.x) : 0;

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

		//Set Values
		massInputField.text = massValue.ToString();
		massExponential.text = massExp.ToString();

		velocityInputField.text = velocityValue.ToString();
		velocityExponential.text = velocityExp.ToString();

		angleSlider.value = angle;
	}
}
