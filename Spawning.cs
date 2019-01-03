using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Spawns enemys randomly around the player

public class Spawning : MonoBehaviour {

	[SerializeField] private GameObject Spawnpoint1;
	[SerializeField] private GameObject Spawnpoint2;
	[SerializeField] private GameObject Spawnpoint3;
	[SerializeField] private GameObject Spawnpoint4;

	[SerializeField] private GameObject EnemyShoot;
	[SerializeField] private GameObject EnemyRun;

	private int enemyCounter;
	public float SpawnTimer = 0.001f;
	private float timer;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer > SpawnTimer && enemyCounter < 15) {

			int r = Random.Range (1, 3);
			int rand = Random.Range (1, 5);


			if (r == 1) {

				if (rand == 1) {
					Instantiate (EnemyShoot, Spawnpoint1.transform.position, Spawnpoint1.transform.rotation);
					enemyCounter++;
					timer = 0;

				} else if (rand == 2) {
					Instantiate (EnemyShoot, Spawnpoint2.transform.position, Spawnpoint2.transform.rotation);
					enemyCounter++;
					timer = 0;

				} else if (rand == 3) {
					Instantiate (EnemyShoot, Spawnpoint3.transform.position, Spawnpoint3.transform.rotation);
					enemyCounter++;
					timer = 0;

				} else if (rand == 4) {
					Instantiate (EnemyShoot, Spawnpoint4.transform.position, Spawnpoint4.transform.rotation);
					enemyCounter++;
					timer = 0;

				}
			} else if (r == 2) {

				if (rand == 1) {
					Instantiate (EnemyRun, Spawnpoint1.transform.position, Spawnpoint1.transform.rotation);
					enemyCounter++;
					timer = 0;

				} else if (rand == 2) {
					Instantiate (EnemyRun, Spawnpoint2.transform.position, Spawnpoint2.transform.rotation);
					enemyCounter++;
					timer = 0;

				} else if (rand == 3) {
					Instantiate (EnemyRun, Spawnpoint3.transform.position, Spawnpoint3.transform.rotation);
					enemyCounter++;
					timer = 0;

				} else if (rand == 4) {
					Instantiate (EnemyRun, Spawnpoint4.transform.position, Spawnpoint4.transform.rotation);
					enemyCounter++;
					timer = 0;

				}
			}
		}
	}

	public void decrementCounter(){

		enemyCounter--;
	}
}
