using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FireThrowerManager : MonoBehaviour {

	public BoxCollider flameCollider;
	public ParticleSystem fire;
	private AudioSource fireSound;
	private bool isOnFire = false;

	public void Start(){
		fire.gameObject.SetActive (false);
		flameCollider.gameObject.SetActive(false);
		fireSound = this.GetComponent<AudioSource> ();
	}
		
	public void TryToTurnOn()
	{
		if(!isOnFire)
			isOnFire = true;
	}

	public void TryToTurnOff()
	{
		if(isOnFire)
			isOnFire = false;
	}

	public void Update(){
		if (isOnFire) {
			flameCollider.gameObject.SetActive(true);
			fire.gameObject.SetActive (true);
			if (!fireSound.isPlaying)
				fireSound.Play ();
		} else {
			flameCollider.gameObject.SetActive(false);
			fire.gameObject.SetActive (false);
			if (fireSound.isPlaying)
				fireSound.Stop ();
		}
	}

}
