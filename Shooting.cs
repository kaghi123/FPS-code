using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//controlls the shooting for the npcs

public class Shooting : MonoBehaviour {

	[SerializeField] protected GameObject fireballPrefab;
	private GameObject _fireball;

	private bool _alive;
	Transform player;
	private float timer;

	void Start() {
		_alive = true;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update() {
		if (_alive) {

			float distance = Vector3.Distance (player.transform.position, transform.position);

			if (distance <= 10.0f && distance > 1.5f) {

				Vector3 lookVector = player.transform.position - transform.position;
				lookVector.y = transform.position.y;
				Quaternion rot = Quaternion.LookRotation(lookVector);
				transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
				transform.Translate(0, 0, 2.8f * Time.deltaTime);



				timer += Time.deltaTime;

				if (timer >= 1.0f) {
					_fireball = Instantiate (fireballPrefab) as GameObject;
					_fireball.transform.rotation = transform.localRotation;
					_fireball.transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y + 1.6f, transform.localPosition.z);
					timer = 0;
				}
			}
			else if (distance <= 1.5f) {
				transform.Translate(0, 0, 0.0f * Time.deltaTime);
			}

			if (_fireball != null) {
				_fireball.transform.Translate(0, 0, 7.0f * Time.deltaTime);
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	public void goToAlarm(Vector3 loc){
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = loc;
	}
}
