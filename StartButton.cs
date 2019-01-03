using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
	[SerializeField] private GameObject StartMenu;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject cameraCutScene;
	[SerializeField] private GameObject canvas;
	[SerializeField] private GameObject heli;


	// Use this for initialization
	void Start () {
		StartMenu.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (StartMenu.activeInHierarchy) {
			Time.timeScale = 0f;

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

			WeaponPickup wp = FindObjectOfType<WeaponPickup> ();
			if(wp != null){
				wp.SetAlive(false);
			}

			SwitchWeapon sw = GameObject.Find ("Camera").GetComponent<SwitchWeapon> ();
			if(sw != null){
				sw.SetAlive(false);
			}

			MouseLook ml = FindObjectOfType<MouseLook> ();
			if(ml != null){
				ml.SetAlive(false);
			}

			player.GetComponent<MouseLook> ().enabled = false;
		}
	}

	public void buttonClick(){

		Time.timeScale = 1f;

		StartMenu.SetActive (false);

		StartCoroutine (startCutScene());

	}

	private IEnumerator startCutScene() {
		
		player.SetActive (false);

		canvas.SetActive (false);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		cameraCutScene.SetActive (true);

		heli.SetActive (true);

		yield return new WaitForSeconds (5.0f);

		player.SetActive (true);

		canvas.SetActive (true);

		cameraCutScene.SetActive (false);

		heli.SetActive (false);



		WeaponPickup wp = FindObjectOfType<WeaponPickup> ();
		if(wp != null){
			wp.SetAlive(true);
		}

		SwitchWeapon sw = GameObject.Find ("Camera").GetComponent<SwitchWeapon> ();
		if(sw != null){
			sw.SetAlive(true);
		}

		MouseLook ml = FindObjectOfType<MouseLook> ();
		if(ml != null){
			ml.SetAlive(true);
		}

		player.GetComponent<MouseLook> ().enabled = true;
	}
}
