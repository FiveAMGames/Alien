using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerMovement : MonoBehaviour 
{
	
	
	private Vector3 _moveDirection = Vector3.zero;
	private CharacterController _controller;

	public float speed = 1.5F;

	private Vector3 moveDirection = Vector3.zero;


	public bool moveable = true;

	public void Awake()
	{
		//fetch character controller
		_controller = GetComponent<CharacterController>();
	}




	//unity update
	public void Update()
	{
		if (moveable) {

			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 3.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;



			//transform.Rotate (0, 0, 0); 
			//transform.Translate (-x, 0, -z, Space.World);    //Translate ignores collider collisions -> move the code to SimpleMove * speed

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//moveDirection *= speed;

			/*
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (-moveHorizontal, 0.0f, -moveVertical);
			GetComponent<Rigidbody>().velocity = movement * speed;
			GetComponent<Rigidbody> ().AddForce (moveDirection);*/

			if (Input.GetKey ("w")) {
				//transform.Translate (Vector3.back, speed, 0, 0);
			_controller.SimpleMove (-Vector3.forward * speed);

			}
			if (Input.GetKey ("s")) {
				_controller.SimpleMove (Vector3.forward * speed);
			}
			if (Input.GetKey ("a")) {
				_controller.SimpleMove (Vector3.right * speed);
			}
			if (Input.GetKey ("d")) {
				_controller.SimpleMove (-Vector3.right * speed);
			}


			
			






			if (x != 0 || z != 0) {
			


				transform.LookAt (new Vector3 (transform.position.x - x, transform.position.y, transform.position.z - z));

			}
			
			if ((Mathf.Abs (Input.GetAxis ("Horizontal")) > 0f) || Mathf.Abs (Input.GetAxis ("Vertical")) > 0f) {
				GetComponentInChildren<AnimationCharacter> ().onWalking = true;

			} else {
				GetComponentInChildren<AnimationCharacter> ().onWalking = false;

			}
		}
	}
}
