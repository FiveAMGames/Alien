using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesShadowsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().receiveShadows = true;
		//GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
		GetComponent<Renderer> ().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
