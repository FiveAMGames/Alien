using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {


	public bool start = true;
	// Use this for initialization
	void Start () {
		GameObject.Find ("Cursor").GetComponent<CursorTextures> ().NormalCurs ();
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartGame(){
		SceneManager.LoadScene ("BedScene");
	}
	public void Quit(){
		Application.Quit();
	}

	void OnMouseDown(){
		if (start) {
			GetComponentInParent<Animator> ().SetBool ("Quit", true);
		} else {
			GetComponentInParent<Animator> ().SetBool ("Start", true);
		}
	}
}
