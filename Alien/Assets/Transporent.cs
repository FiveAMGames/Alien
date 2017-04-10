using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporent : MonoBehaviour {
	GameObject player;
	float alphaNull = 0.5f;
	float alphaStart = 1.0f;

	float duraction = 2.0f;
	Material startColor;
	Material material;

	bool transparent = false;

	Vector3 distToPlayer;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		material = GetComponent<Renderer> ().material;
		startColor = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		distToPlayer = this.transform.position - player.transform.position;

		//float lerp = Mathf.PingPong (Time.time, duraction) / duraction;
		if (transform.position.z > player.transform.position.z + 0.8f && distToPlayer.magnitude <  2f ) {
		//	GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f, alphaNull);
			GetComponent<Renderer> ().material.color = new Color (startColor.color.r, startColor.color.g, startColor.color.b, Mathf.Lerp(alphaStart, alphaNull, duraction));
			//GetComponent<Collider> ().enabled = false;
			this.gameObject.layer = 0;
			transparent = true;
		} else {
			GetComponent<Renderer> ().material.color = new Color (startColor.color.r, startColor.color.g, startColor.color.b, Mathf.Lerp(alphaNull, alphaStart, duraction));
			//GetComponent<Collider> ().enabled = true;
			this.gameObject.layer = 8;
			transparent = false;
		}
	}
}
