using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour {

	public static  DontDestroyMusic Instance { get; private set; }

	public AudioClip endMusic;
	public AudioClip standartMusic;
	private AudioSource aud;

	public bool fadeOut = false;

	void Awake(){
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;

		}
		Instance = this;



		DontDestroyOnLoad(gameObject);
		aud = GetComponent<AudioSource> ();


		 



	}
	void Start(){
		
	}

	void OnLevelWasLoaded(){
		Scene scene = SceneManager.GetActiveScene ();
		if (scene.buildIndex == 1 || scene.buildIndex ==2) {
			if (aud.clip != standartMusic) {
				NormalMusic ();
			}


		} if (scene.buildIndex == 0 && aud.clip != endMusic) {
			
			EndMusic ();

		}
	}

	void Update(){
		if (fadeOut && aud.volume > 0f) {
			aud.volume -= 1 * Time.deltaTime;
		} else if(!fadeOut && aud.volume < 1f ) {
			aud.volume += 1 * Time.deltaTime;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			SceneManager.LoadScene (3);
		}
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
