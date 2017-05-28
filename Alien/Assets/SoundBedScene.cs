using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBedScene : MonoBehaviour {

	public AudioClip[] bedClips;

	private AudioSource aud;
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SorryForMatthew(){
		aud.clip = bedClips [2];
		aud.Play ();
	}
	public void TodayIsADay(){
		aud.clip = bedClips [0];
		aud.Play ();
	}
	public void LikeUsual(){
		aud.clip = bedClips [1];
		aud.Play ();
	}
	public void StartIntro(){
		aud.clip = bedClips [0];
		aud.Play ();
	}
}
