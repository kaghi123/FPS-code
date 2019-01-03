using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//This script is for the hostage npc, it follows the player when the player is near

public class Hostage : MonoBehaviour {
	private bool follow;
	[SerializeField] private GameObject followloc;
	[SerializeField] private GameObject Objective1;
	[SerializeField] private GameObject Objective2;
	[SerializeField] private GameObject SafeZone;
	NavMeshAgent agent;
	private GameObject hostage;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		follow = false;
		StartCoroutine(StartObj1 ());
	}

	private IEnumerator StartObj1() {

		Objective1.SetActive (true);
		yield return new WaitForSeconds (10.0f);
		Objective1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (follow) {
			agent.SetDestination (followloc.transform.position);
		}	
	}

	void OnTriggerEnter(Collider other) {
		
		//PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		follow = true;
		StartCoroutine(StartObj2 ());
		this.GetComponent<SphereCollider> ().enabled = false;

		SafeZone.SetActive (true);

		BossTrigger bt = FindObjectOfType<BossTrigger> ();
		if(bt != null){
			bt.SetActive(true);
		}
	}

	private IEnumerator StartObj2() {

		Objective2.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		Objective2.SetActive (false);
	}
}