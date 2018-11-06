using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private string HorizontalInputName, VerticalInputName;
	[SerializeField] private float movementSpeed;
	[SerializeField] private GameObject flashlight;
	private CharacterController charController;

	public LevelBlock7Controller[] levelBloco7;

	private bool clicou = false;


	// Use this for initialization
	void Start () {
		charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		PlayerMovement ();
		ToggleFlashlight ();

		if (Input.GetButton ("Fire1")) {
			clicou = true;
			print (clicou);
		}
		clicou = false;



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

	void OnCollisionEnter(Collision c){
		print ("Collision Tag : " + c.gameObject.tag);
		if (c.collider.gameObject.tag == "Door") {
			c.collider.SendMessage ("Use");
		}
	}

	void OnTriggerStay(Collider c){
		print ("Collider Tag : " + c.gameObject.tag);
		if (c.gameObject.tag == "LevelBlockBloco7") {
			foreach(LevelBlock7Controller x in levelBloco7){
				if (x == c.gameObject.GetComponent<LevelBlock7Controller>()) {
					print ("TAROLANDO");
					x.PlayerIsIn = true;
				}
			}

			print ("entrou");
		}
		if (c.gameObject.tag == "Door")  {
			if (Input.GetButton ("Fire1")) {
				print ("clicou");
				c.gameObject.SendMessage ("Use", SendMessageOptions.RequireReceiver);
			}
		}
		if (c.gameObject.tag == "1") {

		}
		if (c.gameObject.tag == "2") {

		}
		if (c.gameObject.tag == "3") {

		}
	}
	void OnTriggerEnter(Collider c){
		print (c.gameObject.tag);
		if (c.gameObject.tag == "LevelBlockBloco7") {
			foreach(LevelBlock7Controller x in levelBloco7){
				if (x == c.gameObject.GetComponent<LevelBlock7Controller>()) {
					print ("TAROLANDO");
					x.TurnObjectsOn();
				}
			}

			print ("entrou");
		}
	}

	void OnTriggerExit(Collider c){
		print (c.gameObject.tag);

		if (c.gameObject.tag == "LevelBlockBloco7") {
			foreach(LevelBlock7Controller x in levelBloco7){
				if (x == c.gameObject.GetComponent<LevelBlock7Controller>()) {
					print ("TAROLANDO");
					x.PlayerIsIn = false;;
				}
			}

			print ("entrou");
		}
		print ("saiu");
	}

	/*void onTriggerEnter(Collider c){
		if (c.gameObject.tag == "LevelBlockBloco7") {
			levelBloco7.TurnObjectsOn ();
			print ("entrou");
		}
	}*/
}
