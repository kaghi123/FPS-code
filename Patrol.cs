using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//moves a navmesh argent around

public class Patrol : MonoBehaviour {

	public float wanderRadius;
	public float wanderTimer;

	private Transform target;
	private NavMeshAgent agent;
	private float timer;
	private bool _alive;

	Animator anim;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		timer = wanderTimer;
		_alive = true;

		anim = GetComponent<Animator>();
		//animator.SetBool ("Idle", false);
		anim.SetBool ("isWalking", true);
		//animator.SetBool ("Running", false);
		//animator.SetBool ("Jumping", false);

	}
	
	// Update is called once per frame
	void Update () {
		if (_alive) {
		timer += Time.deltaTime;

			if (timer >= wanderTimer) {
				Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				agent.SetDestination(newPos);
				anim.SetBool ("isIdle", false);
				anim.SetBool ("isWalking", true);
				timer = 0;
			}

			if (transform.position.y < -1) {
				Destroy(this.gameObject);
				GameObject s = GameObject.FindGameObjectWithTag ("Respawn");
				Spawning sp = s.GetComponent<Spawning> ();
				sp.decrementCounter ();
			}

		anim.SetBool ("isWalking", false);
		anim.SetBool ("isIdle", true);
		}
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = (Random.insideUnitSphere * dist) / 2;

		randDirection += origin;

		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
