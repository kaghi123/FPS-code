using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
	public AudioListener audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioListener> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.O) && audio.enabled == true) {

			audio.enabled = false;
		}
		if(Input.GetKey (KeyCode.O) && audio.enabled == false){
			
			audio.enabled = true;
		}
	}
}
