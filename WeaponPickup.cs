using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script hadles the shooting for the weapons and also makes sure
//that the weapons has enough ammo

public class WeaponPickup : MonoBehaviour {
	[SerializeField] private GameObject Playerweapon;
	[SerializeField] private Camera _camera;
	[SerializeField] private GameObject Hole;
	[SerializeField] private AudioSource handgun;
	[SerializeField] private AudioSource ak47;
	int lammo;
	int sammo;
	private bool _alive;

	void Start(){
		_alive = true;
	}
	
	void Update() {
		if (_alive) {
			Ammo l = FindObjectOfType<Ammo> ();
			if(l != null){
				lammo = l.getLammo ();
			}

			Ammo s = FindObjectOfType<Ammo> ();
			if(s != null){
				sammo = s.getSammo ();

			}

			if((Playerweapon.activeInHierarchy  && Playerweapon.name.Contains("Handgun") && sammo > 0) || (Playerweapon.activeInHierarchy && Playerweapon.name.Contains("AK-47") && lammo > 0)){
				if (Input.GetMouseButtonDown(0)) {
					if (Playerweapon.name.Contains ("Handgun")) {
						handgun.Play ();
					}
					else if (Playerweapon.name.Contains("AK-47")){
						ak47.Play ();
					}

					Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
					Ray ray = _camera.ScreenPointToRay(point);
					RaycastHit hit;
					if (Physics.Raycast (ray, out hit)) {
						GameObject hitObject = hit.transform.gameObject;
						ReactiveTarget target = hitObject.GetComponent<ReactiveTarget> ();
						Boss b = hitObject.GetComponent<Boss> ();
						if (target != null) {
							target.ReactToHit ();
						} else if (b != null){
							b.ReactToHit ();
						}else {
							StartCoroutine (BulletHole (hit.point, hit));
						}
					}
				}
			}
		}


	}

	private IEnumerator BulletHole(Vector3 pos, RaycastHit hit) {
		GameObject clone = Instantiate(Hole, pos, Quaternion.FromToRotation(Vector3.up, hit.normal));
		yield return new WaitForSeconds(1);
		Destroy(clone, 3.0f);
	}

	public void StopShoot(){
		Playerweapon.SetActive (false);
	}

	public string getPlayerWeapon(){
		return Playerweapon.name;
	}

	public void SetAlive(bool alive) {
		_alive = alive;
	}

	public bool GetAlive(){
		return _alive;
	}
}
