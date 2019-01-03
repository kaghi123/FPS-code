using UnityEngine;
using System.Collections;
public class Fireball : MonoBehaviour {

	//original fireball script

	public int damage = 1;

	void Update() {
		transform.Translate(0, 0, 7.0f * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}
		Destroy(this.gameObject); // Do Not Use Destory(this);
	}
}