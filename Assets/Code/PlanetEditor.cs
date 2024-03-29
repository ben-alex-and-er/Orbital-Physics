using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlanetEditor : MonoBehaviour
{
	public TMP_Text planetName;

	[SerializeField]
	protected GravityController gravityController;
	[SerializeField]
	protected SystemController systemController;

	[Header("Mass")]

	[SerializeField]
	protected TMP_InputField massInputField;
	[SerializeField]
	protected TMP_InputField massExponential;

	[Header("Velocity")]

	[SerializeField]
	protected TMP_InputField velocityInputField;
	[SerializeField]
	protected TMP_InputField velocityExponential;

	[Header("Angle")]
	[SerializeField]
	protected Slider angleSlider;
	[SerializeField]
	protected TMP_Text angleText;
	[SerializeField]
	protected GameObject arrow;

	[Header("Editor")]
	[SerializeField]
	protected bool disableEditor;

	protected double massValue;
	protected int massExp = 1;
	protected double velocityValue;
	protected int velocityExp = 1;
	protected float angle;
	protected double initialMultiplier;
	protected bool paused = true;

	public abstract void OnPause(bool pause);

	public abstract void SetPlanet(BaseObject obj, bool b);
}
