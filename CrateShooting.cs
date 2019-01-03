using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the crate enemys that dont move and only shoot when the enemy is near by

public class CrateShooting : MonoBehaviour {

	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;


	private bool _alive;
	Transform player;
	private float timer;

	void Start() {
		_alive = true;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		timer = 0;
	}

	void Update() {
		if (_alive) {

			float distance = Vector3.Distance (player.transform.position, transform.position);

			if (distance <= 10.0f) {
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

				Vector3 lookVector = player.transform.position - transform.position;
				lookVector.y = transform.position.y;
				Quaternion rot = Quaternion.LookRotation (lookVector);
				transform.rotation = Quaternion.Slerp (transform.rotation, rot, 1);


				timer += Time.deltaTime;

				if (timer >= 1.0f) {
					_fireball = Instantiate (fireballPrefab) as GameObject;
					_fireball.transform.rotation = transform.localRotation;
					_fireball.transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y + 1.6f, transform.localPosition.z);
					timer = 0;
				}

				Shooting s = FindObjectOfType<Shooting> ();
				if(s != null){
					s.goToAlarm(this.transform.position);
				}

			} else {
				crouch ();
			}
			if (_fireball != null) {
				_fireball.transform.Translate(0, 0, 4.0f * Time.deltaTime);
			}
		}
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	public void crouch(){
		//transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - 1.0f, transform.localPosition.z);
	}
}
