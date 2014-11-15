using UnityEngine;
using System.Collections;

public class CS_DestroyObjects : MonoBehaviour {

	public GameObject destroyer;

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject == destroyer) 
		{
			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
}
}
