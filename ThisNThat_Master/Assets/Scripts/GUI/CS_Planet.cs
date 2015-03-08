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
	[HideInInspector] public Quaternion endRotation;

	void Awake ()
	{
		levelSelect = GameObject.Find("GameState").GetComponent<CS_LevelSelect>();
		solarSystem = GameObject.Find("Planets");
	}

	void Update () 
	{
		transform.LookAt (referenceLocation);
		print(solarSystem.transform.eulerAngles);
		solarSystem.transform.rotation = Quaternion.Slerp(solarSystem.transform.rotation, endRotation, lerpSpeed * Time.deltaTime);
		//if (endRotation.eulerAngles == solarSystem.transform.eulerAngles)
		//{	lerpSpeed = 0;	}
	}

	void OnMouseUp ()
	{
		switch (planet)
		{
			case PlanetType.Forest:
				levelSelect.ForestPlanet();
				endRotation.eulerAngles = new  Vector3 (0,0,0);
				break;
			case PlanetType.Arctic:
				levelSelect.ArcticPlanet();
				//lerpSpeed = 2.0f;
				endRotation.eulerAngles = new Vector3 (0,90,0);
				break;
			case PlanetType.Cave:
				levelSelect.CavePlanet();
				//lerpSpeed = 0;
				endRotation.eulerAngles = new Vector3 (0,180,0);
				//lerpSpeed = 2.0f;
				break;
			case PlanetType.Volcano:
				levelSelect.VolcanoPlanet();
				endRotation.eulerAngles = new Vector3 (0,270,0);
				break;
			default:
				break;
		}
	}

	void CalculateRotation()
	{

	}
}
