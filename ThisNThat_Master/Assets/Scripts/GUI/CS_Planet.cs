using UnityEngine;
using System.Collections;

public class CS_Planet : MonoBehaviour 
{

	public enum PlanetType {Null, Forest, Arctic, Cave, Volcano}
	public PlanetType planet;
	private CS_LevelSelect levelSelect;
	public GameObject solarSystem;
	public Transform referenceLocation;

	private float lerpSpeed = 2.0f;
	[HideInInspector] public static Quaternion endRotation;

	void Awake ()
	{

		levelSelect = GameObject.Find("GameState").GetComponent<CS_LevelSelect>();
		solarSystem = GameObject.Find("Planets");
		CS_Planet.endRotation = solarSystem.transform.rotation;
	}

	void Update () 
	{
		transform.LookAt (referenceLocation);
		print(solarSystem.transform.eulerAngles);
		solarSystem.transform.rotation = Quaternion.Slerp(solarSystem.transform.rotation, CS_Planet.endRotation, lerpSpeed * Time.deltaTime);
	}

	void OnMouseUp ()
	{
		switch (planet)
		{
			case PlanetType.Forest:
				levelSelect.ForestPlanet();
				CS_Planet.endRotation.eulerAngles = new  Vector3 (0,0,0);
				break;
			case PlanetType.Arctic:
				levelSelect.ArcticPlanet();
				CS_Planet.endRotation.eulerAngles = new Vector3 (0,90,0);
				break;
			case PlanetType.Cave:
				levelSelect.CavePlanet();
				CS_Planet.endRotation.eulerAngles = new Vector3 (0,180,0);
				break;
			case PlanetType.Volcano:
				levelSelect.VolcanoPlanet();
			CS_Planet.endRotation.eulerAngles = new Vector3 (0,270,0);
				break;
			default:
				break;
		}
	}

	void CalculateRotation()
	{

	}
}
