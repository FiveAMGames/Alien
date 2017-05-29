using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedTransparensy : MonoBehaviour {

	private Material[] oldMaterial;
	public Material[] transpMaterial;
	// Use this for initialization
	void Start () {
		oldMaterial = GetComponent<Renderer>().materials;
		GetComponent<Renderer> ().materials = transpMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
