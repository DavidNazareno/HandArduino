using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform objective;
    public Animator anim;
    public float life = 50;
    public GameObject bullet;
    public Transform bulletPoint;
    public float forceShooting;
    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent.destination = objective.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            anim.SetTrigger("dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Finish"))
        {
            agent.isStopped = true;
            
            anim.SetTrigger("shoot");


        }

        if (other.gameObject.CompareTag("bulletP"))
        {
            life--;

            

        }
    }

    private void OnDrawGizmos()
    {
        if(objective != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, objective.position);
        }
       
    }

    public void Shooting()
    {
        GameObject ins = (GameObject)Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        ins.GetComponent<Rigidbody>().velocity = bulletPoint.forward * forceShooting;
        
    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }
}
