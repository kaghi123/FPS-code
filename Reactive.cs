using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This script has the reaction for the different types of NPCs

public class Reactive : MonoBehaviour
{
    Animator anim;
    Transform player;
    private bool _alive;

    int shotcount = 0;

    // Use this for initialization
    void Start()
    {
        _alive = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    public void ReactToHit()
    {

        if (shotcount == 1)
        {
            Shooting behavior = GetComponent<Shooting>();
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }

            WanderingNPC b = GetComponent<WanderingNPC>();
            if (b != null)
            {
                b.SetAlive(false);
            }

            GameObject s = GameObject.FindGameObjectWithTag("Respawn");
            Spawning sp = s.GetComponent<Spawning>();
            sp.decrementCounter();
            anim.SetBool("isDead", true);

            //StartCoroutine(Dead());
        }
        else
        {
            shotcount++;
        }

    }

    private IEnumerator Dead()
    {

        if (this.GetComponent<NavMeshAgent>().enabled)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
        }
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }

}
