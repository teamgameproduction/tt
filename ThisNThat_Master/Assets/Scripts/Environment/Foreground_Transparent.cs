using UnityEngine;
using System.Collections;

public class Foreground_Transparent : MonoBehaviour {

	[HideInInspector]	public GameObject 	gmcharacterRed;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
						public GameObject ForeGroundElement;
						private Renderer ForeGroundRenderer;
						public Material ForegroundMAT;

	void Start () {
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		ForeGroundRenderer = ForeGroundElement.GetComponent <Renderer> ();
		ForegroundMAT = ForeGroundRenderer.material;
	}
	
	void Update () {
	


	}

	void OnTriggerEnter (Collider Other){

			ForegroundMAT.SetFloat ("_Cutoff", 0.2F);
	}

	void OnTriggerStay (Collider Other){

			
			ForegroundMAT.SetFloat ("_Cutoff", 0.2F);
		}

	void OnTriggerExit (Collider Other){
					
			ForegroundMAT.SetFloat ("_Cutoff", 1.0F);

	}
}
