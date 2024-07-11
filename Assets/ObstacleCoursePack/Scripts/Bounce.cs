using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bounce : MonoBehaviour
{
	public float force = 10f; //Force 10000f
	public float stunTime = 0.5f;
	private Vector3 hitDir;
    bool walkPointSet = false;
    private Vector3 walkPoint;
    public float walkPointRange = 60f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Patroling();
    }

    void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
				hitDir = contact.normal;
				collision.gameObject.GetComponent<CharacterControls>().HitPlayer(-hitDir * force, stunTime);
				return;
			}
		}
		/*if (collision.relativeVelocity.magnitude > 2)
		{
			if (collision.gameObject.tag == "Player")
			{
				//Debug.Log("Hit");
				collision.gameObject.GetComponent<CharacterControls>().HitPlayer(-hitDir*force, stunTime);
			}
			//audioSource.Play();
		}*/
	}
   

   
    private void Patroling()
    {

        // Update walkPoint continuously for random movement
        SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        // Update walkPoint with random position
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint + Vector3.up, -transform.up, 2f))
            walkPointSet = true;
    }

}
