using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour {

	public static  DontDestroyMusic Instance { get; private set; }

	public AudioClip endMusic;
	public AudioClip standartMusic;
	private AudioSource aud;

	void Awake(){
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;

		}
		Instance = this;



		DontDestroyOnLoad(gameObject);
		aud = GetComponent<AudioSource> ();
		Scene scene = SceneManager.GetActiveScene ();

		if (scene.name == "my" || scene.name =="BedScene"){
			NormalMusic ();
			aud.Play ();

		}



	}
	void Start(){
			
	}

	public void EndMusic(){
		aud.clip = endMusic;
		aud.Play ();
	}
	public void NormalMusic(){
		aud.clip = standartMusic;
		aud.Play ();
	}

}
