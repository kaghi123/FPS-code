using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for the health packs
//It deactivates when its triggered and calls the heal method from playercharacter

public class HealthPack : MonoBehaviour {
	public int heal = 2;
	[SerializeField] protected GameObject healthPack;



	void OnTriggerEnter(Collider other) {
		healthPack.SetActive (false);
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        player.Heal (heal);
	}
}
