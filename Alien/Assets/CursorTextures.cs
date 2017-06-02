using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTextures : MonoBehaviour {

	public Texture2D interaction;
	public Texture2D  normal;
	public Texture2D  item;
	public Texture2D  alpha;

	public CursorMode cursorMode = CursorMode.ForceSoftware;
	public Vector2 hotspot = Vector2.zero;

	private GameObject player;

	void Start () {
		Cursor.SetCursor (alpha, hotspot,CursorMode.ForceSoftware);
		player = GameObject.Find ("Player");
	}
	

	void Update () {
		
	}
	public void ItemCurs(){
		Cursor.SetCursor (item, hotspot,CursorMode.ForceSoftware);
	}

	public void NormalCurs(){
		Cursor.SetCursor (normal, hotspot,CursorMode.ForceSoftware);
	}

	public void AlphaCurs(){
		Cursor.SetCursor (alpha, hotspot,CursorMode.ForceSoftware);
	}

	public void InteractionCurs(){
		Cursor.SetCursor (interaction, hotspot,CursorMode.ForceSoftware);
	}
}

