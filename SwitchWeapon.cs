using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script makes it so you can switch weapons and it aslo switches the GUI for the weapons

public class SwitchWeapon : MonoBehaviour {
	[SerializeField] private GameObject weapon1;
	[SerializeField] private GameObject weapon1pic;
	[SerializeField] private GameObject weapon1pictext;
	[SerializeField] private GameObject weapon2;
	[SerializeField] private GameObject weapon2pic;
	[SerializeField] private GameObject weapon2pictext;
	private bool _alive;

	// Use this for initialization
	void Start () {
		_alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_alive) {
			if (weapon1.activeInHierarchy) {
				if (Input.GetMouseButtonDown (1)) {
					weapon1.SetActive (false);
					weapon1pic.SetActive (false);
					weapon1pictext.SetActive (false);
					weapon2.SetActive (true);
					weapon2pic.SetActive (true);
					weapon2pictext.SetActive (true);
				}
			} else {
				if (Input.GetMouseButtonDown (1)) {
					weapon1.SetActive (true);
					weapon1pic.SetActive (true);
					weapon1pictext.SetActive (true);
					weapon2.SetActive (false);
					weapon2pic.SetActive (false);
					weapon2pictext.SetActive (false);
				}
			}
		}

	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
