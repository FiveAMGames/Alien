﻿using System.Collections;
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
	public void UnsolvedRubik(){
		aud.clip = clips[1];
		aud.Play();
	}
	public void CatDeservesSomeFood(){

		 
			aud.clip = clips [2];
			aud.Play ();
		}


	public void CatFoodBuah(){
		
			int rand = Random.Range (0, 3);
			if (rand == 0) {
				aud.clip = clips [3];
				aud.Play ();
			}
			if (rand == 1) {
				aud.clip = clips [4];
				aud.Play ();
			}
			if (rand == 2) {
				aud.clip = clips [5];
				aud.Play ();
			}

	}
	public void CatYouWillEat(){
		aud.clip = clips [6];
		aud.Play ();
	}
	public void MatthewTakesKey(){
		aud.clip = clips [7];
		aud.Play ();
	}
	public void FinallyICanGetOut(){
		aud.clip = clips [8];
		aud.Play ();
	}
	public void MatthewGetOffLollipop(){
		aud.clip = clips [9];
		aud.Play ();
	}
	public void GreenAlien(){
		aud.clip = clips [10];
		aud.Play ();
	}
	public void CatForBuisness(){
		aud.clip = clips [11];
		aud.Play ();
	}
	public void BabyDoesntWantLollipopAnymore(){
		aud.clip = clips [12];
		aud.Play ();
	}
	public void CatWillComeBack(){
		aud.clip = clips [13];
		aud.Play ();
	}
}
