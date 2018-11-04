using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

	[SerializeField] private string mouseXInputName, mouseYInputName;
	[SerializeField] private float mouseSensitivty;
	[SerializeField] private Transform PlayerTransform; 

	private float xAxisLimit;

	void Awake(){

		LockCursor ();
	}

	// Use this for initialization
	void Start () {
		xAxisLimit = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {

		CameraRotation ();

	}

	private void LockCursor(){

		Cursor.lockState = CursorLockMode.Locked;
	}

	private void CameraRotation(){

		float MouseX = Input.GetAxis (mouseXInputName) * mouseSensitivty * Time.deltaTime;
		float MouseY = Input.GetAxis (mouseYInputName) * mouseSensitivty * Time.deltaTime;


		xAxisLimit += MouseY;
		if (xAxisLimit > 70f) {
			xAxisLimit = 70f;
			MouseY = 0;
			ClampXAxisRotationToValue (-70f);
		}
		if (xAxisLimit < -70f) {
			xAxisLimit = -70f;
			MouseY = 0;
			ClampXAxisRotationToValue (70f);
		}

		transform.Rotate (Vector3.left * MouseY);
		PlayerTransform.Rotate(Vector3.up * MouseX);
	}

	private void ClampXAxisRotationToValue(float value){
		Vector3 eulerRotation = transform.eulerAngles;
		eulerRotation.x = value;
		transform.eulerAngles = eulerRotation;
	}
}
