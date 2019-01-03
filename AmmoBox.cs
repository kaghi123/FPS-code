using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is for the ammo boxes
//Whenever one is triggered it removes the box and adds the ammo to whaatever weapon is active

public class AmmoBox : MonoBehaviour {
	public int ammo = 5;
	[SerializeField] private GameObject ammoBox;
	int lammo;
	int sammo;

	void OnTriggerEnter(Collider other) {
		ammoBox.SetActive (false);

		Ammo a = FindObjectOfType<Ammo> ();

		if(a != null){
			lammo = a.getLammo ();
			sammo = a.getSammo ();
		}

		WeaponPickup wp = FindObjectOfType<WeaponPickup> ();
		if(wp != null){
			string name = wp.getPlayerWeapon ();

			if (name.Contains ("Handgun")) {
				a.setSammo (sammo + ammo);
			} else {
				a.setLammo (lammo + ammo);
			}
		}


	}
}
