using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	[SerializeField] private GameObject pauseText;
	[SerializeField] private GameObject exitText;
	[SerializeField] private GameObject audioText;
	[SerializeField] private GameObject Startmenu;
	public GameObject player;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			
			if (Time.timeScale == 1.0f) {
				pauseText.SetActive (true);
				exitText.SetActive (true);
				audioText.SetActive (true);

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



				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

				Time.timeScale = 0.0f;

			}
			else if (Time.timeScale == 0.0f) {
				pauseText.SetActive (false);
				exitText.SetActive (false);
				audioText.SetActive (false);

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

				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				Time.timeScale = 1.0f;
			}
		}
	}
}
