using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LollipopBowlTriggerScript : MonoBehaviour {

	public GameObject catAnim;
	public Transform whereToPlaceLollipop;
	public GameObject bubblePassOut;
	public GameObject BubbleHunger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){

		if (coll.name == "lollipop") {
			if (!coll.GetComponent<MyItem> ().inInventory) {
				coll.gameObject.transform.position = whereToPlaceLollipop.position;
				coll.gameObject.transform.rotation = whereToPlaceLollipop.rotation;

				coll.GetComponent<MyItem> ().matthewProperty = true;
				catAnim.GetComponent<Animator> ().SetTrigger ("Lollipop");
				catAnim.GetComponentInParent<MyItem> ().matthewProperty = false;

				Destroy (BubbleHunger);
				bubblePassOut.SetActive (true);
				catAnim.GetComponentInParent<catAnimation> ().Miauu ();
				Destroy (gameObject);
			}
		}
	}

}
