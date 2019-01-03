using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script keeps track of the ammo for the weapons
//it also changes the GUI whenever ammo is used
//and has getters and setters for when ammoboxes are used

public class Ammo : MonoBehaviour {
	[SerializeField] private GameObject weapon1pictext;
	[SerializeField] private GameObject weapon2pictext;
	int sammo = 9;
	int lammo = 20;
	bool alive;


	// Use this for initialization
	void Start () {
		weapon1pictext.GetComponent<UnityEngine.UI.Text> ().text = sammo.ToString();
		weapon2pictext.GetComponent<UnityEngine.UI.Text> ().text = lammo.ToString();
		alive = true;

	}
	
	// Update is called once per frame
	void Update () {
		WeaponPickup wp = FindObjectOfType<WeaponPickup> ();
		if(wp != null){
			alive = wp.GetAlive ();
		}
		if (alive) {
			if (Input.GetMouseButtonDown (0)) {
				if (weapon1pictext.activeInHierarchy && sammo > 0) {
					sammo--;
					weapon1pictext.GetComponent<UnityEngine.UI.Text> ().text = sammo.ToString();
				} else if(weapon2pictext.activeInHierarchy && lammo > 0) {
					lammo--;
					weapon2pictext.GetComponent<UnityEngine.UI.Text> ().text = lammo.ToString();
				}
			}
		}
	}

	public int getSammo(){
		return sammo;
	}

	public int getLammo(){
		return lammo;
	}

	public void setSammo(int ammo){
		sammo = ammo;
		weapon1pictext.GetComponent<UnityEngine.UI.Text> ().text = sammo.ToString();
	}

	public void setLammo(int ammo){
		lammo = ammo;
		weapon2pictext.GetComponent<UnityEngine.UI.Text> ().text = lammo.ToString();
	}
}