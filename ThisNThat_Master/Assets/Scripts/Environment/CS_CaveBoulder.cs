using UnityEngine;
using System.Collections;

public class CS_CaveBoulder : MonoBehaviour 
{
		
		[HideInInspector]	public Vector3 StartPos;
		public GameObject respawnthis;

		
		
		// Use this for initialization
		void Start () {
			//respawnthis= GameObject.FindGameObjectWithTag("ComeBack");
			//StartPos = respawnthisgroup.transform.position;

			StartPos = respawnthis.transform.position;
			}

		
		// Update is called once per frame
		
		void OnTriggerEnter (Collider other)
		{
		if (other.gameObject.tag == "Player") {
			respawnthis.transform.position = StartPos;
		}
		}
}

