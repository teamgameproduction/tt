using UnityEngine;
using System.Collections;

public class CS_BlinkingLights : MonoBehaviour {
	
	public float lerpTime = 0.5f;
	private float i = 0;
	
	public int maxDist = 5;
	public float speed = 40.0f;
	
	
	// Use this for initialization
	void Start () {
		light.range = 0;
	}
	
	// Update is called once per frame
	void Update () {

			light.range = Mathf.PingPong(Time.time * speed, maxDist);
			
			i+= Time.deltaTime;
	}
	
}
