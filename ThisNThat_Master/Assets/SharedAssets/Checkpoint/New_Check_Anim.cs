using UnityEngine;
using System.Collections;

public class New_Check_Anim : MonoBehaviour {

	private Animator CheckPointAnim;

	void Start () {

		CheckPointAnim = gameObject.GetComponent <Animator> ();
	}

	void OnCollisionEnter (){

		CheckPointAnim.SetBool("Spawn", true);


		}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp ("u")) {

			CheckPointAnim.SetBool("Spawn", true);

		}
	}
}
