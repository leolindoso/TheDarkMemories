using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockBlockLab3Controller : MonoBehaviour {

	[SerializeField] GameObject[] ObjectsInRange;
	public bool PlayerIsIn;
	// Use this for initialization
	void Start () {
		
		foreach (GameObject i in ObjectsInRange) {
			i.SetActive (false);
			PlayerIsIn = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerIsIn == true) {
			foreach (GameObject i in ObjectsInRange) {
				i.SetActive (true);
				PlayerIsIn = true;
			}
		} else {
			foreach (GameObject i in ObjectsInRange) {
				i.SetActive (false);
				PlayerIsIn = false;
			}
		}
	}

	public void TurnObjectsOn(){
		print ("entrou");
		if (PlayerIsIn == false) {
			PlayerIsIn = true;
		} else {
			PlayerIsIn = false;
		}	

	}
}
