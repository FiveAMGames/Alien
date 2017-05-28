using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour {

	public string nameOfInteractableObject;
	public GameObject destroyParticles;
	public GameObject whatHappens;
	public GameObject setActive;
	float dist = 0f;

	public bool greenAlien = false;
	MyInventory inventory;

	// Use this for initialization
	void Start () {
		inventory = GameObject.Find ("Game").GetComponent<MyInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		dist = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
		//print("Distance to other: " + dist);
	}

	public void Go(){
		Debug.Log ("Yay! Interaction!!!");
		if (greenAlien) {
		
			if ((inventory.getItemInHand ().name == nameOfInteractableObject) && dist < 6f) {   //TODO doesn't work properly. NullReference O_o
				//inventory.removeItem (inventory.getItemInHand ());
				/*if (destroyParticles != null) {
				var expl = Instantiate (destroyParticles, transform.position, Quaternion.identity);
				Destroy (inventory.getItemInHand ().gameObject);

				inventory.removeItem (inventory.getItemInHand ());
				Destroy (this.gameObject);
				Destroy (expl, 3);
			}*/
				Debug.Log ("Boom");

				if (setActive != null) {

					Destroy (inventory.getItemInHand ().gameObject);

					inventory.removeItem (inventory.getItemInHand ());
					setActive.SetActive (true);
				}
				if (whatHappens != null) {
					whatHappens.SendMessage ("Go");

						GetComponent<Collider> ().enabled = false;

				}
			} else {
				Debug.Log ("Wrong item!");
			}
		
		}
		else if ((inventory.getItemInHand ().name == nameOfInteractableObject) && dist < 4f) {   //TODO doesn't work properly. NullReference O_o
			//inventory.removeItem (inventory.getItemInHand ());
			/*if (destroyParticles != null) {
				var expl = Instantiate (destroyParticles, transform.position, Quaternion.identity);
				Destroy (inventory.getItemInHand ().gameObject);

				inventory.removeItem (inventory.getItemInHand ());
				Destroy (this.gameObject);
				Destroy (expl, 3);
			}*/
			Debug.Log ("Boom");

			if (setActive != null) {
				
				Destroy (inventory.getItemInHand ().gameObject);

				inventory.removeItem (inventory.getItemInHand ());
				setActive.SetActive (true);
			}
			if (whatHappens != null) {
				whatHappens.SendMessage ("Go");

			}
		} else {
			Debug.Log ("Wrong item!");
		}
	}

	public bool CheckIfInteractable(string name){
		if (dist < 4f) {
			return name == nameOfInteractableObject;
		} else
			return false;
			
		
	}
}
