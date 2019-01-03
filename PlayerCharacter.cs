using UnityEngine;
using System.Collections;
public class PlayerCharacter : MonoBehaviour {

	//This script keeps track of the players health and also the GUI for the health

	private int _health;
	[SerializeField] private GameObject Gameovert;
	[SerializeField] private GameObject resett;
	[SerializeField] private GameObject exitt;
	[SerializeField] private GameObject healthbar1;
	[SerializeField] private GameObject healthbar2;
	[SerializeField] private GameObject healthbar3;
	[SerializeField] private GameObject healthbar4;
	[SerializeField] private GameObject healthbar5;
	[SerializeField] private GameObject healthbar6;
	[SerializeField] private GameObject healthbar7;
	[SerializeField] private GameObject healthbar8;
	[SerializeField] private GameObject healthbar9;
	[SerializeField] private GameObject healthbar10;
	[SerializeField] private GameObject healthbar11;



	void Start() {
		_health = 5;
	}

	void Update() {
		if (_health == 0) {

			FPSInput f = GetComponent<FPSInput> ();
			f.SetAlive(false);

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


			Gameovert.SetActive (true);
			resett.SetActive (true);
			exitt.SetActive (true);
		}

		if (_health == 0) {
			healthbar1.SetActive (false);
			healthbar2.SetActive (false);
			healthbar3.SetActive (false);
			healthbar4.SetActive (false);
			healthbar5.SetActive (false);
			healthbar6.SetActive (false);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}


		if (_health == 1) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (false);
			healthbar3.SetActive (false);
			healthbar4.SetActive (false);
			healthbar5.SetActive (false);
			healthbar6.SetActive (false);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 2) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (false);
			healthbar4.SetActive (false);
			healthbar5.SetActive (false);
			healthbar6.SetActive (false);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 3) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (false);
			healthbar5.SetActive (false);
			healthbar6.SetActive (false);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 4) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (false);
			healthbar6.SetActive (false);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 5) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (false);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 6) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (true);
			healthbar7.SetActive (false);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 7) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (true);
			healthbar7.SetActive (true);
			healthbar8.SetActive (false);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 8) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (true);
			healthbar7.SetActive (true);
			healthbar8.SetActive (true);
			healthbar9.SetActive (false);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 9) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (true);
			healthbar7.SetActive (true);
			healthbar8.SetActive (true);
			healthbar9.SetActive (true);
			healthbar10.SetActive (false);
			healthbar11.SetActive (false);
		}

		if (_health == 10) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (true);
			healthbar7.SetActive (true);
			healthbar8.SetActive (true);
			healthbar9.SetActive (true);
			healthbar10.SetActive (true);
			healthbar11.SetActive (false);
		}

		if (_health == 11) {
			healthbar1.SetActive (true);
			healthbar2.SetActive (true);
			healthbar3.SetActive (true);
			healthbar4.SetActive (true);
			healthbar5.SetActive (true);
			healthbar6.SetActive (true);
			healthbar7.SetActive (true);
			healthbar8.SetActive (true);
			healthbar9.SetActive (true);
			healthbar10.SetActive (true);
			healthbar11.SetActive (true);
		}
	}
	 
	public void Hurt(int damage) {
		_health -= damage;
	}

	public void Heal(int heal) {
		_health += heal;
	}

}
