using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private string HorizontalInputName, VerticalInputName;
	[SerializeField] private float movementSpeed;
	[SerializeField] private GameObject flashlight;
	private CharacterController charController;


	// Use this for initialization
	void Start () {
		charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		PlayerMovement ();
		ToggleFlashlight ();



	}

	private void PlayerMovement(){

		float verticalInput = Input.GetAxis(VerticalInputName)*movementSpeed*Time.deltaTime;
		float horizontalInput = Input.GetAxis(HorizontalInputName)*movementSpeed*Time.deltaTime;

		Vector3 fowardMovement = transform.forward * verticalInput;
		Vector3 horizontalMovement = transform.right * horizontalInput;

		if (Input.GetKey ("left shift")) {
			movementSpeed = 300;
		} else {
			movementSpeed = 150;
		}
		charController.SimpleMove (fowardMovement + horizontalMovement);
	}

	private void ToggleFlashlight(){
		if (Input.GetKeyDown ("f")) {
			print ("f");
			if (flashlight.active == true) {
				flashlight.SetActive (false);
			} else {
				flashlight.SetActive (true);
			}
		}
	}
}
