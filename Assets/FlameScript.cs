using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour {

	public float damageValue = 5;

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Monster"))
			other.gameObject.SendMessage ("Hit", damageValue);
	}
}