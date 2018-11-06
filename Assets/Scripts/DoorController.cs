using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	private Animator animator;

	private bool IsOpen = false;
	private bool IsOpening = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Use(){
		if (IsOpen == false) {
			IsOpening = true;
			animator.SetBool ("IsOpening", true);
			animator.SetBool ("IsClosing", false);
			IsOpen = true;
		} else {
			IsOpening = false;
			animator.SetBool ("IsOpening", false);
			animator.SetBool ("IsClosing", true);
			IsOpen = false;
		}
	}
}
