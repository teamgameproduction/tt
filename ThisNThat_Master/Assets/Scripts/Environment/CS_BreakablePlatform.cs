using UnityEngine;
using System.Collections;

public class CS_BreakablePlatform : MonoBehaviour 
{
	public CS_GenericTrigger CollisionBool;
	public GameObject TriggerVolume;
	public float destroyTimer = 100.0f;
	public bool isTouch = false;
	
	void Start () 
	{
		CollisionBool = TriggerVolume.GetComponent<CS_GenericTrigger>();
	}

	void Update () 
	{
		//if (destroyTimer == 0.0f)
		//{}
		 if (isTouch == true && destroyTimer > 0.0f)
		{
			//destroyTimer -= Time.deltaTime;
			destroyTimer--;
		}
		else if (isTouch == true && destroyTimer <= 0.0f)
		{
			DestroyObject(this.gameObject);
		}
	}
	void OnCollisionEnter (Collision other)
	{
				//if (!other.gameObject.tag == "Player") {
						//return;
			
				//}

				isTouch = true;
		}

}
