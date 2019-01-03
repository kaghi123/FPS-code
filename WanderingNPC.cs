using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Similar to WanderingAI except these NPC dont shoot the just turn around and run qickly

public class WanderingNPC : MonoBehaviour {

	public float wanderRadius;
	public float wanderTimer;

	private Transform target;
	private NavMeshAgent agent;
	private float timer;
	private Transform player;
	private Vector3 a;
	private Vector3 b;
	private Vector3 c;
	private Vector3 d;
	private Vector3 dest;
	private float dis;

	private bool _alive;
	private bool running;

	void Start() {
		_alive = true;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent> ();
		timer = wanderTimer;
		running = false;
	}

	void Update() {
		if (_alive) {

			if (transform.position.y < -1) {
				Destroy(this.gameObject);
			}

			float distance = Vector3.Distance (player.transform.position, transform.position);

			if (distance <= 10.0f) {

				Vector3 lookVector = player.transform.position - transform.position;
				lookVector.y = transform.position.y;
				Quaternion rot = Quaternion.LookRotation (-lookVector);
				transform.rotation = Quaternion.Slerp (transform.rotation, rot, 1);


				if (!running) {
					NavMeshAgent agent = GetComponent<NavMeshAgent> ();


					a = new Vector3 (-20.89f, 0.39f, 23.703f);
					b = new Vector3 (19.37f, 0.39f, -36.61f);
					c = new Vector3 (-22.79f, 0.39f,-34.62f);
					d = new Vector3 (2.56f, 0.3f, 37.84f);

					float distance1 = Vector3.Distance (a, transform.position);
					float distance2 = Vector3.Distance (b, transform.position);
					float distance3 = Vector3.Distance (c, transform.position);
					float distance4 = Vector3.Distance (d, transform.position);

					float dis = Mathf.Max (Mathf.Max (distance1, distance2), Mathf.Max (distance3, distance4));

					if (dis == distance1) {
						dest = a;
					} else if (dis == distance2) {
						dest = b;
					} else if (dis == distance3) {
						dest = c;
					} else if (dis == distance4) {
						dest = d;
					}

					running = true;
				}  

				if (running) {

					agent.destination = dest;
					agent.speed = 7.0f;
					if (Vector3.Distance(dest, transform.position) < 3.0f) {
						running = false;
						agent.speed = 2.0f;
					}
				}

			} else if (distance > 10.0f && !running) {
				agent.speed = 2.0f;
				timer += Time.deltaTime;
				if (timer >= wanderTimer) {
					Vector3 newPos = RandomNavSphere (transform.position, wanderRadius, -1);
					agent.SetDestination (newPos);
					//animator.SetBool ("Idle", false);
					//animator.SetBool ("Walking", true);
					timer = 0;

				}
			} else if (distance > 10.0f && running) {
				agent.destination = dest;
				agent.speed = 7.0f;
				if (Vector3.Distance(dest, transform.position) < 3.0f) {
					running = false;
					agent.speed = 2.0f;
				}
			}
		}
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
		Vector3 randDirection = (Random.insideUnitCircle * dist);

		randDirection += origin;

		NavMeshHit navHit;

		NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);

		return navHit.position;
	}


	public void SetAlive(bool alive) {
		_alive = alive;
	}
}