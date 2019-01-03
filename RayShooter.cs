using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//original rayshooter

public class RayShooter : MonoBehaviour {
	private Camera _camera;

	void Start() {
		_camera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 48;
		float posX = _camera.pixelWidth/2 - size/16;
		float posY = _camera.pixelHeight/2 - size/8;
		GUI.Label(new Rect(posX, posY, size, size), "+");
	}


}