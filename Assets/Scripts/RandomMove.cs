using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour
{
	private NavMeshAgent  _agent;
	
    void Start()
	{
        _agent = GetComponent<NavMeshAgent>();
	
    }

    void Update()
    {
        if(Vector3.Distance(_agent.destination, transform.position) < 2f)
		{
			float randomX = Random.Range(-5f, 5f);
			float randomZ = Random.Range(-5f, 5f);
			
			Vector3 randomPosition = new Vector3(transform.position.x + randomX, 
												transform.position.y, 
												transform.position.z + randomZ);
												
			_agent.destination = randomPosition;
			
		}
		
    }
}
