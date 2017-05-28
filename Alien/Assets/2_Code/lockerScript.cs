using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerScript : MonoBehaviour {
	public GameObject alienInBed;
	// Use this for initialization

	public Texture2D  normal;
	public  Texture2D  interactionCursor;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotspot = Vector2.zero;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AnimationEnd(){
		alienInBed.GetComponent<Animator> ().SetTrigger ("Freedom");
	}
	void OnMouseEnter(){
		Cursor.SetCursor (interactionCursor, hotspot, CursorMode.ForceSoftware);
	}

	void OnMouseExit(){
		Cursor.SetCursor (normal, Vector2.zero, CursorMode.ForceSoftware);
	}
}
