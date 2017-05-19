using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAnimationTrigger : MonoBehaviour {
	public GameObject player;
	public Transform whereToPlace; //in flat
	public Transform PlaceGround; //on the ground
	private bool onAnimation;
	public Transform positionOnTheGround;
	public Transform positionInTheFlat;


	public bool upTrigger = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (onAnimation) {
			float playerY = player.transform.position.y;
			if (!upTrigger) {
				if (player.transform.position.y > PlaceGround.transform.position.y) {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y - 2 * Time.deltaTime, player.transform.position.z);
				} else {
					
					player.GetComponentInChildren<AnimationCharacter> ().RopeOut ();

					if (playerY > positionOnTheGround.transform.position.y) {
						player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y - 3f * Time.deltaTime, player.transform.position.z);
					} else {
						onAnimation = false;
						player.GetComponent<PlayerMovement> ().moveable = true;
					}
				}
			}
			else {

				if (player.transform.position.y < whereToPlace.transform.position.y) {
					player.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 2 * Time.deltaTime, player.transform.position.z);
				} else {
					
					player.GetComponentInChildren<AnimationCharacter> ().RopeOut ();

					player.transform.position = positionInTheFlat.position;
						onAnimation = false;
						player.GetComponent<PlayerMovement> ().moveable = true;
					}
				}





		
		
		} 
	}
	void OnMouseDown(){
		if (!onAnimation) {
			if (!upTrigger) {
				player.transform.position = whereToPlace.position; 
				player.transform.rotation = whereToPlace.rotation; 
				player.GetComponentInChildren<AnimationCharacter> ().Rope ();
				onAnimation = true;
				player.GetComponent<PlayerMovement> ().moveable = false;
			} else {
				player.transform.position = PlaceGround.position;
				player.transform.rotation = PlaceGround.rotation;
				player.GetComponentInChildren<AnimationCharacter> ().Rope ();
				onAnimation = true;
				player.GetComponent<PlayerMovement> ().moveable = false;
			}
		}
	}
}
