using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour {
	[SerializeField] private GameObject Hostage;
	[SerializeField] private GameObject Wall;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject canvas;
	[SerializeField] private GameObject cameraCutScene;
	[SerializeField] private GameObject bossCutScene;
	[SerializeField] private GameObject boss;
	[SerializeField] private GameObject trigger;
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
		if (player != null) {
			if (safe) {
				StartCoroutine (startCutScene());
				Wall.SetActive (true);
				Hostage.SetActive (false);
			}
		}
			
	}

	public void SetActive(bool safez){
		safe = safez;
	}

	private IEnumerator startCutScene() {

		player.SetActive (false);

		canvas.SetActive (false);

		bossCutScene.SetActive (true);

		cameraCutScene.SetActive (true);

		yield return new WaitForSeconds (3.5f);

		trigger.SetActive (false);

		player.SetActive (true);

		canvas.SetActive (true);

		boss.SetActive (true);

		bossCutScene.SetActive (false);

		cameraCutScene.SetActive (false);


	}
}
