using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint2 : MonoBehaviour {
	[SerializeField] private GameObject checkpointtxt;
	[SerializeField] private GameObject checkpoint2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		PlayerPrefs.GetInt("Checkpoint", 2);
		StartCoroutine (checkpoint());

	}

	private IEnumerator checkpoint() {

		checkpointtxt.SetActive (true);
		yield return new WaitForSeconds (5.0f);
		checkpointtxt.SetActive (false);
		checkpoint2.SetActive (false);
	}
}
