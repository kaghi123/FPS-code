using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//when the player reaches the safe zone with the hostage, the mission is complete

public class SafeZone : MonoBehaviour {

	[SerializeField] private GameObject missiontext;
	[SerializeField] private GameObject resett;
	[SerializeField] private GameObject exitt;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject hostage;
	[SerializeField] private GameObject cameraCutScene;
	[SerializeField] private GameObject heli;
	private bool safe;

	// Use this for initialization
	void Start () {
		safe = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if(safe){
			missiontext.SetActive(true);
			resett.SetActive (true);
			exitt.SetActive (true);


			FPSInput f = FindObjectOfType<FPSInput> ();
			if (f != null) {
				f.SetAlive (false);
			}

			WeaponPickup wp = FindObjectOfType<WeaponPickup> ();
			if(wp != null){
				wp.SetAlive(false);
			}

			SwitchWeapon sw = GameObject.Find ("Camera").GetComponent<SwitchWeapon> ();
			if(sw != null){
				sw.SetAlive(false);
			}

			GameObject[] e = GameObject.FindGameObjectsWithTag ("Enemy");

			Shooting[] s = new Shooting[e.Length];
			for (int i = 0; i < e.Length; i++) {
				s[i] = e [i].GetComponent<Shooting> ();
				if (s [i] != null) {
					s[i].SetAlive(false);
				}
			}

			CrateShooting[] cs = new CrateShooting[e.Length];
			for (int i = 0; i < e.Length; i++) {
				cs[i] = e [i].GetComponent<CrateShooting> ();
				if (cs [i] != null) {
					cs[i].SetAlive(false);
				}
			}

			StartCoroutine (startCutScene());

		}
	}

	public void SetActive(bool safez){
		safe = safez;
	}

	private IEnumerator startCutScene() {

		player.SetActive (false);

		hostage.SetActive (false);

		heli.SetActive (true);

		cameraCutScene.SetActive (true);

		yield return new WaitForSeconds (4.9f);

		heli.SetActive (false);

		var animator = cameraCutScene.GetComponent<Animator>();
		animator.speed = 0;
	}
}
