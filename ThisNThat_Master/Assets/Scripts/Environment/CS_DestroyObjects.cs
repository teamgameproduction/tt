using UnityEngine;
using System.Collections;

public class CS_DestroyObjects : MonoBehaviour {

	public GameObject destroyer;
//	public GameObject airVent;

	void Start () {

		//destroyer = GameObject.Find ("Snow_Ball_Cover");
		//airVent = GameObject.Find ("UpDraft_01");

		}

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject == destroyer) 
		{
			//Destroy(destroyer);
			gameObject.SetActive(false);
		}
}
}
