using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	public bool gonnaGetcha = false;
	public CS_Checkpoint_Controller cS_CheckPoint_Controller;
	// Use this for initialization
	void Start () {
		cS_CheckPoint_Controller = GameObject.Find ("GameState").GetComponent<CS_Checkpoint_Controller>();
	}
	
	// Update is called once per frame
	void Update () {


		if (gonnaGetcha == true) {

			transform.Translate (Vector3.right * Time.deltaTime * -1);

				}


						
	
	}

	void OnTriggerEnter (Collider other)
	{
		if(!other.CompareTag("Player"))
		{
			return;
		}
		gonnaGetcha = true;
		
		
	}
}
