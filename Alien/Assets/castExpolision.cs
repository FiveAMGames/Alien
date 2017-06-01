using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class castExpolision : MonoBehaviour {

	public Transform playersPlaceAfterHammer;
	public GameObject runAwayPos;
	public GameObject runAwayAnim;
	public GameObject gypsum;
	public GameObject playerAnim;
	 // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator waitSeconds(){
		GameObject.Find ("Player").transform.position = playersPlaceAfterHammer.position;
		GameObject.Find ("Player").transform.rotation = playersPlaceAfterHammer.rotation;
		playerAnim.GetComponent<Animator> ().SetTrigger ("newFriendTrigger");
		GameObject.Find ("Player").GetComponent<PlayerMovement> ().moveable = false;
		Camera.main.GetComponent<CameraScript> ().hammerScene = true;
		runAwayAnim.GetComponent<Animator> ().SetBool ("Go", true);
		runAwayPos.GetComponent<Animator> ().SetBool ("RunAway", true);

		yield return new WaitForSeconds (2f);
		GetComponentInParent<Animator> ().SetBool ("CastBreak", true);
		Camera.main.GetComponent<VoiceOverScript> ().LastVoice ();
		Camera.main.GetComponent<Animator> ().enabled = true;
		Destroy (gameObject);
	}
	public void Go(){
		//StartCoroutine(SplitMesh(true));
		gypsum.SetActive(true);
		GetComponent<Renderer> ().enabled = false;
		StartCoroutine (waitSeconds ());
	
	}
	public IEnumerator SplitMesh (bool destroy)    {

		if(GetComponent<MeshFilter>() == null || GetComponent<SkinnedMeshRenderer>() == null) {
			yield return null;
		}

		if(GetComponent<Collider>()) {
			GetComponent<Collider>().enabled = false;
		}

		Mesh M = new Mesh();
		if(GetComponent<MeshFilter>()) {
			M = GetComponent<MeshFilter>().mesh;
		}
		else if(GetComponent<SkinnedMeshRenderer>()) {
			M = GetComponent<SkinnedMeshRenderer>().sharedMesh;
		}

		Material[] materials = new Material[0];
		if(GetComponent<MeshRenderer>()) {
			materials = GetComponent<MeshRenderer>().materials;
		}
		else if(GetComponent<SkinnedMeshRenderer>()) {
			materials = GetComponent<SkinnedMeshRenderer>().materials;
		}

		Vector3[] verts = M.vertices;
		Vector3[] normals = M.normals;
		Vector2[] uvs = M.uv;
		for (int submesh = 0; submesh < M.subMeshCount; submesh++) {

			int[] indices = M.GetTriangles(submesh);

			for (int i = 0; i < indices.Length; i += 3)    {
				Vector3[] newVerts = new Vector3[3];
				Vector3[] newNormals = new Vector3[3];
				Vector2[] newUvs = new Vector2[3];
				for (int n = 0; n < 3; n++)    {
					int index = indices[i + n];
					newVerts[n] = verts[index];
					newUvs[n] = uvs[index];
					newNormals[n] = normals[index];
				}

				Mesh mesh = new Mesh();
				mesh.vertices = newVerts;
				mesh.normals = newNormals;
				mesh.uv = newUvs;

				mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

				GameObject GO = new GameObject("Triangle " + (i / 3));
				//GO.layer = LayerMask.NameToLayer("Particle");
				GO.transform.position = transform.position;
				GO.transform.rotation = transform.rotation;
				GO.AddComponent<MeshRenderer>().material = materials[submesh];
				GO.AddComponent<MeshFilter>().mesh = mesh;
				GO.AddComponent<BoxCollider>();
				Vector3 explosionPos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(0f, 0.5f), transform.position.z + Random.Range(-0.5f, 0.5f));
				GO.AddComponent<Rigidbody>().AddExplosionForce(Random.Range(300,500), explosionPos, 5);
				Destroy(GO, 5 + Random.Range(0.0f, 5.0f));
			}
		}

		GetComponent<Renderer>().enabled = false;

		yield return new WaitForSeconds(1.0f);
		if(destroy == true) {
			Destroy(gameObject);
		}

	}


}

