using UnityEngine;
using System.Collections;

public class CS_RedAnimCTRL : MonoBehaviour {

	public Animator animator;
	public CS_FlapReset flapReset;
	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator>();
		flapReset = GameObject.Find ("characterRed").GetComponent< CS_FlapReset>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("d") && flapReset.Grounded == true || Input.GetKey ("a") && flapReset.Grounded == true){
			animator.SetBool ("Running", true);
		}

		else {
			animator.SetBool ("Running", false);
		}

		if (Input.GetKeyDown ("space") && flapReset.Grounded == true){
		animator.SetBool ("Jump", true);
		}

		else if (flapReset.Grounded == true){
			animator.SetBool ("Jump", false);
			animator.SetBool ("Falling", false);
		}

		if (Input.GetMouseButtonDown (0)){
			animator.SetBool ("Smashing", true);
		}

		else{
			animator.SetBool ("Smashing", false);
		}
	}
}
