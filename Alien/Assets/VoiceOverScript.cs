using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverScript : MonoBehaviour {
	public AudioClip[] clips;
	private AudioSource aud;

	void Start(){
		aud = GetComponent<AudioSource> ();
	}


	public void StartLevel(){
		aud.clip = clips[0];
		aud.Play();
	}
}
