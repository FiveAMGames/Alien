using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowScript : MonoBehaviour {
	public GameObject pillowAfter;
	public GameObject key;

	public Texture2D  normal;
	public Texture2D interactionCursor;
	public CursorMode cursorMode = CursorMode.ForceSoftware;
	public Vector2 hotspot = Vector2.zero;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		pillowAfter.SetActive (enabled);
		Destroy (gameObject);
		key.GetComponent<Collider> ().enabled = true;
	}
	void OnMouseEnter(){
		Cursor.SetCursor (interactionCursor, hotspot, CursorMode.ForceSoftware);
	}

	void OnMouseExit(){
		Cursor.SetCursor (normal, Vector2.zero, CursorMode.ForceSoftware);
	}
}
