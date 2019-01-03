using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;
	public float jump = 2.0f;
	private bool crouch = false;
	[SerializeField] private GameObject Cam;
	private bool _alive;

	private CharacterController _charController;
	
	void Start() {
		_charController = GetComponent<CharacterController>();
		_alive = true;
	}
	
	void Update() {
		if (_alive) {
			//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
			float deltaX = Input.GetAxis("Horizontal") * speed;
			float deltaZ = Input.GetAxis("Vertical") * speed;
			Vector3 movement = new Vector3(deltaX, 0, deltaZ);
			movement = Vector3.ClampMagnitude(movement, speed);

			movement.y = gravity;

			movement *= Time.deltaTime;
			movement = transform.TransformDirection(movement);
			_charController.Move(movement);

			//crouch
			if (Input.GetKeyDown (KeyCode.C)) {
				if (crouch) {
					Cam.transform.localPosition = new Vector3 (0,1,0);
					crouch = false;
					speed = 6.0f;
				} else {
					Cam.transform.localPosition = new Vector3 (0, 0.1f, 0);
					crouch = true;
					speed = 2.0f;
				}

			}

			//sprint
			if (!crouch && Input.GetKey (KeyCode.LeftShift)) {
				speed = 12f;
			} else {
				speed = 6f;
			}

			//jump
			if (_charController.isGrounded && Input.GetKeyDown (KeyCode.Space)) {
				_charController.transform.localPosition = new Vector3 (_charController.transform.localPosition.x, _charController.transform.localPosition.y + jump, _charController.transform.localPosition.z);
			}
		}

	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}
}
