using UnityEngine;
using System.Collections;

public class CS_Win : MonoBehaviour
{

	[HideInInspector]	public GameObject gmcharacterRed;
	[HideInInspector]	public GameObject gmcharacterBlue;

	private CS_Results results;

	private bool alreadyWon = false;

	public bool BlueIsTouching;
	public bool RedIsTouching;

	void Start ()
	{
			results = GameObject.Find("Results").GetComponent<CS_Results>();
			gmcharacterRed = GameObject.Find ("characterRed");
			gmcharacterBlue = GameObject.Find ("characterBlue");
	}

	void Update ()
	{

			if (RedIsTouching == true && BlueIsTouching == true && !alreadyWon) {

				results.GameWon();
				alreadyWon = true;
			}

	}

	void OnTriggerEnter (Collider other)
	{
			if (other.gameObject == gmcharacterRed) {

					RedIsTouching = true;

			} else if (other.gameObject == gmcharacterBlue) {
					BlueIsTouching = true;
			}
	}

	void OnTriggerExit (Collider other)
	{

			if (other.gameObject == gmcharacterRed) {
		
					RedIsTouching = false;
		
			} else if (other.gameObject == gmcharacterBlue) {
					BlueIsTouching = false;
			}
	}
}
