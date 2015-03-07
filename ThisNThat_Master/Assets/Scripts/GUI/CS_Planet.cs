using UnityEngine;
using System.Collections;

public class CS_Planet : MonoBehaviour 
{

	public enum PlanetType {Null, Forest, Arctic, Cave, Volcano}
	public PlanetType planet;
	private CS_LevelSelect levelSelect;
	public Transform referenceLocation;

	void Awake ()
	{
		levelSelect = GameObject.Find("GameState").GetComponent<CS_LevelSelect>();
	}

	void Update () 
	{
		transform.LookAt (referenceLocation);
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
