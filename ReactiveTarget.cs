using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This script has the reaction for the different types of NPCs

public class ReactiveTarget : MonoBehaviour {
	int shotcounter = 0;

	// Use this for initialization

	public void ReactToHit () {

		if (shotcounter == 1) {
			Shooting behavior = GetComponent<Shooting> ();
			if (behavior != null) {
				behavior.SetAlive (false);
			}

			WanderingNPC b = GetComponent<WanderingNPC> ();
			if (b != null) {
				b.SetAlive (false);
			}

			GameObject s = GameObject.FindGameObjectWithTag ("Respawn");
			Spawning sp = s.GetComponent<Spawning> ();
			sp.decrementCounter ();


			StartCoroutine (Die ());
		} else {
			shotcounter++;
		}

	}

	private IEnumerator Die() {

		if (this.GetComponent<NavMeshAgent> ().enabled) {
			this.GetComponent<NavMeshAgent> ().enabled = false;
		}
		this.transform.Rotate(-75, 0, 0);
		yield return new WaitForSeconds(1.5f);
		Destroy(this.gameObject);
	}

}
