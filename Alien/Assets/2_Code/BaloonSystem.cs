using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonSystem : MonoBehaviour {

	public GameObject catFoodBaloon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CatFoodBaloon(){
		catFoodBaloon.SetActive (true);
	}
}
