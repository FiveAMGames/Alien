using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

	public AudioClip takeItemFromInventory;
	public AudioClip takeItemFromWorld;
	public AudioClip jump;
	public AudioClip takeMatthew;
	public AudioClip wrongMatthew;


	AudioSource aud;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayTakeItemFromInventory(){
		aud.PlayOneShot (takeItemFromInventory);
	}
	public void PlayJump(){
		aud.PlayOneShot (jump);
	}
	public void PlayTakeItemFromWorld(){
		aud.PlayOneShot (takeItemFromWorld);
	}
	public void PlayMatthewTake(){
		aud.PlayOneShot (takeMatthew);
	}
	public void Wrong(){
		aud.PlayOneShot (wrongMatthew);
	}
}
