using UnityEngine;
using System.Collections;

public class CS_ComeBack : MonoBehaviour {


	public GameObject comebackobject;
	

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
				print ("activatingchildren");
				comebackobject.SetActiveRecursively(true);
		}
	}

}