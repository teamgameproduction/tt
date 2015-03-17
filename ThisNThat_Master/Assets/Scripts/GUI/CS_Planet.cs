using UnityEngine;
using System.Collections;

public class CS_Planet : MonoBehaviour 
{

	public enum PlanetType {Null, Forest, Arctic, Cave, Volcano}
	public PlanetType planet;
	private CS_LevelSelect levelSelect;
	public GameObject solarSystem;
	public Transform referenceLocation;

	private float lerpSpeed = 1.0f;
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
		//print(solarSystem.transform.eulerAngles);
		solarSystem.transform.rotation = Quaternion.Slerp(solarSystem.transform.rotation, CS_Planet.endRotation, lerpSpeed * Time.deltaTime);
	}

	void OnMouseUp ()
	{
		switch (planet)
		{
			case PlanetType.Forest:
				levelSelect.ForestPlanet();
				break;
			case PlanetType.Arctic:
				levelSelect.ArcticPlanet();
				break;
			case PlanetType.Cave:
				levelSelect.CavePlanet();				
				break;
			case PlanetType.Volcano:
				levelSelect.VolcanoPlanet();
				break;
			default:
				break;
		}
	}
}
