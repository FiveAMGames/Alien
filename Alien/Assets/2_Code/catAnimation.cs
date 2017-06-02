using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catAnimation : MonoBehaviour {
	public GameObject CatGreen;
	public GameObject bubbleLollipop; 
	public GameObject catAnim;
	public GameObject hammer;

	public GameObject DontTouchBubble;
	public AudioClip miau1;
	public AudioClip miau2;
	public AudioClip miauuuuaa;

	public Transform placeGreenAlien;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void Miauu(){
		catAnim.GetComponent<AudioSource> ().PlayOneShot (miauuuuaa); 
	}

	public void StopWalkAnimation(){
		catAnim.GetComponent<Animator> ().SetBool ("Walk", false);
		GetComponent<Animator> ().enabled = false;
		//GetComponent<MyItem> ().matthewProperty = false;
		bubbleLollipop.SetActive (true);
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		Destroy (DontTouchBubble);
	}

	public void Go(){
		GameObject.Find("Game").GetComponent<MyInventory>().removeItem (GameObject.Find("Game").GetComponent<MyInventory>().getItemInHand ());
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<MyItem> ().matthewProperty = true;
		transform.position = placeGreenAlien.position;
		transform.rotation = placeGreenAlien.rotation;

		hammer.transform.parent = null;
		hammer.GetComponent<MyItem> ().matthewProperty = false;
		hammer.GetComponent<Rigidbody> ().isKinematic = false;
		hammer.GetComponent<Collider> ().isTrigger = false;
		CatGreen.SetActive (true);
		Camera.main.GetComponent<VoiceOverScript> ().CatWillComeBack ();
	}

	void OnMouseDown(){
		float dist = Vector3.Distance (GameObject.Find ("Player").transform.position, transform.position);
		if (dist < 3f) {

			if (bubbleLollipop!= null && bubbleLollipop.activeSelf) {
				Camera.main.GetComponent<VoiceOverScript> ().CatYouWillEat ();
			} else {

				if (!catAnim.GetComponent<Animator> ().GetBool("Walk")){
				catAnim.GetComponent<Animator> ().SetTrigger ("DontTouch");

					if (DontTouchBubble!=null){DontTouchBubble.SetActive (true);}

				if (catAnim.GetComponent<AudioSource> ().clip == miau1) {
					catAnim.GetComponent<AudioSource> ().clip = miau2;
						catAnim.GetComponent<AudioSource> ().PlayOneShot(miau2);

				} else {
					catAnim.GetComponent<AudioSource> ().clip = miau1;
						catAnim.GetComponent<AudioSource> ().PlayOneShot (miau1);
				}
				}
					}

		}
	}
}
