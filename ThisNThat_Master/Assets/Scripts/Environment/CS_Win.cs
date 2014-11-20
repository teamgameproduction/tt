using UnityEngine;
using System.Collections;

public class CS_Win : MonoBehaviour {

	[HideInInspector]	public GameObject gmcharacterRed;
	[HideInInspector]	public GameObject gmcharacterBlue;

	public bool BlueIsTouching;
	public bool RedIsTouching;

	// Use this for initialization
	void Start () {
	
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
	}
	
	// Update is called once per frame
	void Update () {

		if (RedIsTouching == true && BlueIsTouching == true) {

			Application.LoadLevel("UI_LevelSelect");
				}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == gmcharacterRed) {

			RedIsTouching = true;

				} else if (other.gameObject == gmcharacterBlue) {
			BlueIsTouching = true;
				}
	}

	void OnTriggerExit(Collider other)
	{

		if (other.gameObject == gmcharacterRed) {
			
			RedIsTouching = false;
			
		} else if (other.gameObject == gmcharacterBlue) {
			BlueIsTouching = false;
		}
	}
}
