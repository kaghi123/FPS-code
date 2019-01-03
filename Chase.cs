using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

    // Use this for initialization
    Transform player;
    private bool _alive;
    //private float timer;

    static Animator anim;
    void Start () {
        _alive = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_alive){
            Vector3 direction = player.position - this.transform.position;
            float angle = Vector3.Angle(direction, this.transform.forward);
            float distance = Vector3.Distance(player.transform.position, this.transform.position);

            if (distance < 10 && angle < 30)
            {

                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                           Quaternion.LookRotation(direction), 0.1f);

                anim.SetBool("isIdle", false);
                if (direction.magnitude > 5)
                {
                    this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttacking", false);
                }
                else
                {
                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);
                }
            }

            else
            {
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
        }

		
	}

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    public void goToAlarm(Vector3 loc)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = loc;
    }
}
