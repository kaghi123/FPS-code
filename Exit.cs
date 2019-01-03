using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E)) {
			//when using an .exe
			Application.Quit();

			//for the editor
			UnityEditor.EditorApplication.isPlaying = false;

		}
	}
}
