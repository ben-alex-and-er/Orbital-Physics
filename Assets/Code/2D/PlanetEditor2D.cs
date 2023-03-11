using UnityEngine;
using System;
using TMPro;

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

	[Header("Line")]
	[SerializeField]
	private GameObject otherObject;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private TMP_Text distance;


	private bool angleSliderInteractableOnStart;

	private void Start()
	{
		if (lineRenderer != null)
			lineRenderer.SetPosition(0, otherObject.transform.position);

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

		SetPlanet(planet, true);
	}

    private void Update()
    {
		if (paused || planet == null)
			return;

		UpdateEditor();

		if (lineRenderer != null)
		{
			lineRenderer.SetPosition(1, planet.transform.position);
			distance.text = (Vector3.Distance(planet.transform.position, otherObject.transform.position) * gravityController.distanceMultiplier).ToString();
			distance.transform.position = Vector3.Lerp(planet.transform.position, otherObject.transform.position, 0.5f);
		}
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

		planet.velocity = new(
			(float)(Mathf.Cos(angle * Mathf.Deg2Rad) * velocity * initialMultiplier), 
			(float)(Mathf.Sin(angle * Mathf.Deg2Rad) * velocity * initialMultiplier));
	}

	private void AngleChange()
    {
		if (!paused)
			return;

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

	public override void SetPlanet(BaseObject newPlanet, bool newCreation)
    {
		planet = (Object2D)newPlanet;
		planetName.text = planet.gameObject.name;

		UpdateEditor(newCreation);

		if (tempCalc != null)
			tempCalc.planet = (Object2D)newPlanet;
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

		float tempAngle;

		if (planet.velocity.x == 0)
		{
			if (planet.velocity.y >= 0)
			{
				tempAngle = Mathf.PI / 2;
			}
			else
			{
				tempAngle = -Mathf.PI / 2;
			}
		}
		else
		{
			tempAngle = Mathf.Atan2(planet.velocity.y, planet.velocity.x);
		}

		tempAngle *= Mathf.Rad2Deg;

		angle = newPlanet ? planet.initialAngle : tempAngle;

		//Set Values
		massInputField.text = massValue.ToString();
		massExponential.text = massExp.ToString();

		velocityInputField.text = velocityValue.ToString();
		velocityExponential.text = velocityExp.ToString();

		angleSlider.value = angle;
		angleText.text = angle.ToString();

		arrow.transform.eulerAngles = new Vector3(0, 0, angle);
	}
}
