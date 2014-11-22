using UnityEngine;
using System.Collections;

public class CS_EmitOnce : MonoBehaviour {
	public float seconds;

	public float lerpTime = 0.5f;
	private float i = 0;
	
	public int maxDist = 5;
	public float speed = 40.0f;

	public bool lightup;
	public bool gotriggerme;

	// Use this for initialization
	void Start () {
		gameObject.light.range=0;
		lightup=false;
		gotriggerme=true;
	}
	
	// Update is called once per frame
	void Update () {
		{
		//	gameObject.light.range = 10;
			
			if(lightup==true)
			light.range = Mathf.PingPong(Time.time * speed, maxDist);
			
			i+= Time.deltaTime;
			
			//gameObject.light.range= 0;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && gotriggerme==true)
		{
			StartCoroutine (ParticleOnce());
			StartCoroutine (LightOnce());
			gotriggerme=false;
		}
	}
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			lightup = false;
			particleEmitter.emit = false;
		}
	}
	IEnumerator ParticleOnce()
	{
		particleEmitter.emit = true;
		yield return new WaitForSeconds(seconds);
		particleEmitter.emit = false;
	}

	IEnumerator LightOnce()
	{
		lightup=true;
	//	gameObject.light.range = 10;
		yield return new WaitForSeconds(seconds);
	//	gameObject.light.range= 0;
		lightup=false;
	}
}
