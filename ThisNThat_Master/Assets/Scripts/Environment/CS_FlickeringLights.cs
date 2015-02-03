using UnityEngine;
using System.Collections;

public class CS_FlickeringLights : MonoBehaviour {
	
	public float lerpTime = 0.5f;
	private float i = 0;
	
	public int maxDist = 5;
	public float speed = 40.0f;

	public float StartingIntensity = 1;

	
	// Use this for initialization
	void Start () {
		//light.intensity = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		light.intensity = (Mathf.PingPong(Time.time * speed, maxDist)) + StartingIntensity;
		
		i+= Time.deltaTime;
	}
	
}