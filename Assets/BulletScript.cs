using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float FlyingSpeed;
	public float LifeTime;
	public GameObject explosion;
	public AudioSource bulletAudio;

	public void InitAndShoot(Vector3 Direction)
	{
		Rigidbody rigidbody = this.GetComponent<Rigidbody> ();

		rigidbody.velocity = Direction * FlyingSpeed;

		Invoke ("KillYourself",LifeTime);
	}

	public void KillYourself()
	{
		GameObject.Destroy (this.gameObject);
	}

	public float damageValue = 15;

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Monster")) {
			other.gameObject.SendMessage ("Hit", damageValue);
		} else if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			PlayerController pc = other.gameObject.GetComponentInChildren<PlayerController> ();
			pc.Hit(10);
		}
		
		explosion.gameObject.transform.parent = null;
		explosion.gameObject.SetActive (true);
		bulletAudio.pitch = Random.Range (0.8f, 1);

		KillYourself ();
	}

}
