using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour {

	[SerializeField] private GameObject Hostage;
	[SerializeField] private GameObject Wall;
	[SerializeField] protected GameObject fireballPrefab;
	private GameObject _fireball;

	Transform player;
	private float timer;
    int shotcounter = 0;

    // Use this for initialization
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update() {

		float distance = Vector3.Distance (player.transform.position, transform.position);
			
		if (distance <= 10.0f && distance > 1.5f) {

			Vector3 lookVector = player.transform.position - transform.position;
			lookVector.y = transform.position.y;
			Quaternion rot = Quaternion.LookRotation(lookVector);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
			transform.Translate(0, 0, 2.8f * Time.deltaTime);

				

			timer += Time.deltaTime;

			if (timer >= 0.5f) {
				_fireball = Instantiate (fireballPrefab) as GameObject;
				_fireball.transform.rotation = transform.localRotation;
				_fireball.transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y + 1.6f, transform.localPosition.z);
				timer = 0;
			}
		}
		else if (distance <= 1.5f) {
			transform.Translate(0, 0, 0.0f * Time.deltaTime);
		}

		if (_fireball != null) {
			_fireball.transform.Translate(0, 0, 7.0f * Time.deltaTime);
		}
	}
		
    public void ReactToHit() {

        if (shotcounter == 5) {
			
            StartCoroutine(Die());
        }
        else
        {
            shotcounter++;
        }

    }

    private IEnumerator Die() {

        if (this.GetComponent<NavMeshAgent>().enabled) {
			
            this.GetComponent<NavMeshAgent>().enabled = false;
        }

        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);

		Hostage.SetActive (true);

		SafeZone sz = FindObjectOfType<SafeZone> ();
		if(sz != null){
			sz.SetActive(true);
		}

		Wall.SetActive (false);

        Destroy(this.gameObject);
    }


}
