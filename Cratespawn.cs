using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script checks if a crate spawn position is empty, if it is then it spawns a crate enemy

public class Cratespawn : MonoBehaviour {

	[SerializeField] public GameObject loc1;
	[SerializeField] private GameObject loc2;
	[SerializeField] private GameObject loc3;
	[SerializeField] private GameObject loc4;
	[SerializeField] private GameObject loc5;
	[SerializeField] private GameObject enemy;
	private float timer = 0.0f;
	public float spawnTimer = 10.0f;

	// Use this for initialization
	void Start () {
		Instantiate (enemy, loc1.transform.position, loc1.transform.rotation);
		Instantiate (enemy, loc2.transform.position, loc2.transform.rotation);
		Instantiate (enemy, loc3.transform.position, loc3.transform.rotation);
		Instantiate (enemy, loc4.transform.position, loc4.transform.rotation);
		Instantiate (enemy, loc5.transform.position, loc5.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		if (!Physics.CheckSphere(loc1.transform.position, 0.01f)) {
			timer += Time.deltaTime;

			if (timer >= spawnTimer) {
				Instantiate (enemy, loc1.transform.position, loc1.transform.rotation);
				timer = 0;
			}
		}

		else if (!Physics.CheckSphere(loc2.transform.position, 0.01f)) {
			timer += Time.deltaTime;

			if (timer >= spawnTimer) {
				Instantiate (enemy, loc2.transform.position, loc2.transform.rotation);
				timer = 0;
			}
		}

		else if (!Physics.CheckSphere(loc3.transform.position, 0.01f)) {
			timer += Time.deltaTime;

			if (timer >= spawnTimer) {
				Instantiate (enemy, loc3.transform.position, loc3.transform.rotation);
				timer = 0;
			}
		}

		else if (!Physics.CheckSphere(loc4.transform.position, 0.01f)) {
			timer += Time.deltaTime;

			if (timer >= spawnTimer) {
				Instantiate (enemy, loc4.transform.position, loc4.transform.rotation);
				timer = 0;
			}
		}

		else if (!Physics.CheckSphere(loc5.transform.position, 0.01f)) {
			timer += Time.deltaTime;

			if (timer >= spawnTimer) {
				Instantiate (enemy, loc5.transform.position, loc5.transform.rotation);
				timer = 0;
			}
		}
	}
}
