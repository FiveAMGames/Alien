using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporent : MonoBehaviour {
	GameObject player;
	float alphaNull = 0.5f;
	float alphaStart = 1.0f;

	public float distanceZForOpacity = 0.0f;
	public float alphaValue = 0f;


	private List<GameObject> thigsOnBed = new List<GameObject>();

	public float duraction = 4.0f;
	Material startColor;
	Material material;


	Renderer[] children;

	public bool outOfSprites = false;

	public bool transparent = false;


	Vector3 distToPlayer;
	// Use this for initialization
	void Start () {
		/*if (outOfSprites) {
			foreach (Transform child in transform) {
				child.gameObject.AddComponent<Transporent> ();
			}
			Destroy (this);
		}*/

		player = GameObject.Find ("Player");
		material = GetComponent<Renderer> ().material;
		startColor = GetComponent<Renderer> ().material;
		if (outOfSprites) {
			children = GetComponentsInChildren<Renderer> ();
		}



	}
	
	// Update is called once per frame
	void Update () {






		distToPlayer = this.transform.position - player.transform.position;

		//float lerp = Mathf.PingPong (Time.time, duraction) / duraction;
		if (transform.position.z > player.transform.position.z + distanceZForOpacity) {
		//	GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f, alphaNull);

			if (!outOfSprites) {
				
				if (material.color.a > alphaValue) {
					
					GetComponent<Renderer> ().material.color = new Color (startColor.color.r, startColor.color.g, startColor.color.b, Mathf.Lerp (alphaStart, material.color.a - 0.01f, duraction));
					if (thigsOnBed.Count > 0) {
						foreach (GameObject item in thigsOnBed) {
							if (item.GetComponent<Rigidbody> () != null) {
								//item.GetComponent<Rigidbody> ().useGravity = false;
								item.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
							}
						}
					}
				}

				//this.gameObject.layer = 0;
			} else {
				print ("Start to change opacity");
				foreach (Renderer child in children) {
					
					Material mat = child.material;
					if (mat.color.a > alphaValue) {
						
						mat.color = new Color (mat.color.r, mat.color.r, mat.color.b, Mathf.Lerp (alphaStart, material.color.a - 0.01f, duraction));
					}
					//GetComponentInChildren<Renderer> ().material.color = new Color (GetComponentInChildren<Renderer> ().material.color.r, GetComponentInChildren<Renderer> ().material.color.g, GetComponentInChildren<Renderer> ().material.color.b, Mathf.Lerp (alphaStart, alphaNull, duraction));
					child.GetComponent<Collider> ().enabled = false;
				}
			}
			GetComponent<Collider> ().enabled = false;
			transparent = true;
		} else {

			if (!outOfSprites) {
				if (material.color.a < 1f) {
					GetComponent<Renderer> ().material.color = new Color (startColor.color.r, startColor.color.g, startColor.color.b, Mathf.Lerp (alphaNull, material.color.a + 0.01f, duraction));
				}
			} else {

				foreach (Renderer child in children) {

					Material mat = child.material;
					if (mat.color.a < 1f) {
						mat.color = new Color (mat.color.r, mat.color.r, mat.color.b, Mathf.Lerp (alphaNull, mat.color.a +0.01f, duraction));
					}

					//GetComponentInChildren<Renderer> ().material.color = new Color (GetComponentInChildren<Renderer> ().material.color.r, GetComponentInChildren<Renderer> ().material.color.g, GetComponentInChildren<Renderer> ().material.color.b, Mathf.Lerp (alphaNull, alphaStart, duraction));

					child.GetComponent<Collider> ().enabled = true;

				}
			}
			GetComponent<Collider> ().enabled = true;
			//this.gameObject.layer = 8;
			transparent = false;
			if (thigsOnBed.Count > 0) {
				foreach (GameObject item in thigsOnBed) {
					if (item.GetComponent<Rigidbody> () != null) {
						//item.GetComponent<Rigidbody> ().useGravity = true;
						item.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
					}
				}
			}
		}
	}

	void OnCollisionEnter(Collision coll){
		print ("oncollisionworks");
		if (coll.gameObject.layer == 9) {

			for (int i = 0; i < thigsOnBed.Count; i++) {
				if (coll.gameObject == thigsOnBed [i]) {
					return;
				}
			}
			thigsOnBed.Add (coll.gameObject);
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.layer == 9) {
			for (int i = 0; i < thigsOnBed.Count; i++) {
				if (coll.gameObject == thigsOnBed [i]) {
					thigsOnBed.Remove (coll.gameObject);
					break;
				}
				
			}
		}
	}

}
