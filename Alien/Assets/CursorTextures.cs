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


	void Start () {
		Cursor.SetCursor (alpha, hotspot,CursorMode.ForceSoftware);
	}
	

	void Update () {
		
	}

	public void NormalCurs(){
		Cursor.SetCursor (normal, hotspot,CursorMode.ForceSoftware);
	}

	public void AlphaCurs(){
		Cursor.SetCursor (alpha, hotspot,CursorMode.ForceSoftware);
	}

}

