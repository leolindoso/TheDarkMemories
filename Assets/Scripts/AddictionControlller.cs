using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AddictionControlller : MonoBehaviour {

	// Use this for initialization

	[SerializeField] private Transform[] PatrolPoints;
	private Animator animator;
	private NavMeshAgent navMeshAgent;
	private int currentPointIndex;

	void Start () {

		navMeshAgent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		bool patrolling = false;
		bool chasing = false;
		bool attacking = false;

		patrolling = !chasing && !attacking && PatrolPoints.Length > 0;


		if (patrolling) {

			if(!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f){
				MoveToNextPatrolPoint ();
			}
		}

		animator.SetBool ("Patrolling", patrolling);
		animator.SetBool ("Chasing", chasing);
		animator.SetBool ("Attacking", attacking);

		
	}
	void MoveToNextPatrolPoint(){
		if (PatrolPoints.Length > 0) {
			navMeshAgent.destination = PatrolPoints [currentPointIndex].position;

			currentPointIndex++;
			currentPointIndex %= PatrolPoints.Length;
		}

	}
	
}
