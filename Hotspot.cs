using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this method is for the hotpots
//basically theres 4 different areas on the map that you can be
//transported to and it is random

public class Hotspot : MonoBehaviour {
	[SerializeField] private GameObject HotspotLoc1;
	[SerializeField] private GameObject HotspotLoc2;
	[SerializeField] private GameObject HotspotLoc3;
	[SerializeField] private GameObject HotspotLoc4;


	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			float rand = Random.Range (1, 5);

			if (rand == 1) {
				player.transform.position = new Vector3 (HotspotLoc1.transform.position.x, HotspotLoc1.transform.position.y, HotspotLoc1.transform.position.z);
			} else if (rand == 2) {
				player.transform.position = new Vector3 (HotspotLoc2.transform.position.x, HotspotLoc2.transform.position.y, HotspotLoc2.transform.position.z);
			} else if (rand == 3) {
				player.transform.position = new Vector3 (HotspotLoc3.transform.position.x, HotspotLoc3.transform.position.y, HotspotLoc3.transform.position.z);
			} else if (rand == 4) {
				player.transform.position = new Vector3(HotspotLoc4.transform.position.x, HotspotLoc4.transform.position.y, HotspotLoc4.transform.position.z);
			}
		}
	}
}
