using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienInBed : MonoBehaviour {

	private CursorTextures curs;
	public GameObject pillow;
	public GameObject key;


	public GameObject youCanDropOrInteract;
	public GameObject takeKeyFromHand;
	public GameObject findKeyInstruction;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		curs = GameObject.Find ("Cursor").GetComponent<CursorTextures> ();
		curs.AlphaCurs ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DropOrInteract(){
		takeKeyFromHand.SetActive (false);
		youCanDropOrInteract.SetActive (true);
	}

	public void Dropped(){
		youCanDropOrInteract.SetActive (false);
	}


	public void KeyInHand(){
		
		GetComponent<Animator> ().SetBool ("Key", true);

		findKeyInstruction.SetActive (false);
		takeKeyFromHand.SetActive (true);
	}
	public void enablePillow(){
		pillow.GetComponent<Collider> ().enabled = true;
		key.GetComponent<Collider> ().enabled = true;
		findKeyInstruction.SetActive (true);
	}

	public void Sorry(){
		GameObject.Find ("Camera").GetComponent<SoundBedScene> ().SorryForMatthew ();
	}
	public void WakeUp(){
		
		GetComponent<Animator> ().SetTrigger ("Start");
	}
	public void UsualDaySound(){
		GameObject.Find ("Camera").GetComponent<SoundBedScene> ().LikeUsual ();
		Cursor.lockState = CursorLockMode.None;
		curs.NormalCurs ();
	}

	public void StartIntro(){
		GameObject.Find ("Camera").GetComponent<SoundBedScene> ().StartIntro ();
	}



	public void FadeStart(){
		GetComponent<fadeSprite> ().BeginFade (1);
		StartCoroutine (loadLevel ());
	}
	IEnumerator loadLevel(){
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (1);
	}

}
