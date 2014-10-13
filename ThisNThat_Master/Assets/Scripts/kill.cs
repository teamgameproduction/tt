using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {
	public CS_Checkpoint_Controller cS_CheckPoint_Controller;
	// Use this for initialization
	void Start () {

		cS_CheckPoint_Controller = GameObject.Find ("GameState").GetComponent<CS_Checkpoint_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		//if(!other.CompareTag("Player"))
		//{
		//	return;
	//	}
		if (other.gameObject.tag == "Player") {

						if (other.gameObject.tag == "Player") {
								cS_CheckPoint_Controller.Die ();
						}
				}
	}
}
