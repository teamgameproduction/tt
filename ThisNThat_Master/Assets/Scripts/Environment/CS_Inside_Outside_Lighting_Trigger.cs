using UnityEngine;
using System.Collections;

public class CS_Inside_Outside_Lighting_Trigger : MonoBehaviour {

	public Color color = new Color(0.6F, 0.6F, 0.6F, 1.0F);
	[HideInInspector]	public GameObject 	mainLight;
	public int In_Out = 1;
	public int inCave = 1;
	public Color fogColorOutside = new Color(1.0F, 1.0F, 1.0F, 1.0F);
	public Color fogColorInside = new Color(0.25F, 0.25F, 0.25F, 1.0F);


	void Start () {
		mainLight = GameObject.Find ("Directional light");		

	}
	
	// Update is called once per frame
	void Update () {

		if (inCave == 2 && mainLight.light.intensity >= 0.0F) {

			mainLight.light.intensity -=0.002F;
		}

		if (inCave == 3 && mainLight.light.intensity <= 0.5F) {

			mainLight.light.intensity +=0.04F;

				}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.tag == "Player") {
						// Set the fog color to be blue;
			if(inCave < 3){
			inCave = inCave + 1;
			}
			else{
			}
						if (inCave == 2) {
								RenderSettings.fogColor = fogColorInside;
								
						
				gameObject.transform.position = new Vector3 (160,-75,0);
				Vector3 temp = transform.rotation.eulerAngles;
				temp.x = 140.0f;
				transform.rotation = Quaternion.Euler(temp);

						}
						if (inCave == 3) {
								RenderSettings.fogColor = fogColorOutside;
						}
				}
	}

}
