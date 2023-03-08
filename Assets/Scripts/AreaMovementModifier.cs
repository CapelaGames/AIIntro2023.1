using UnityEngine;
using UnityEngine.AI;
public class AreaMovementModifier : MonoBehaviour
{
    private NavMeshAgent _agent;
    public float _speed = 10f;
    public float _grassSpeed = 5f;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //surface we are on (hit)
        NavMeshHit hit;
        _agent.SamplePathPosition(-1, 0.0f, out hit);
        
        //The mask we want to compair to.
        int mask = 1 << NavMesh.GetAreaFromName("Grass");
        mask = mask | 1 << NavMesh.GetAreaFromName("Ice");
        
        // does the hit match the mask
        int filtered = hit.mask & mask;

        if (filtered == 0) //not on grass or ice
        {
            _agent.speed = _speed;
        }
        else // we are on grass or ice
        {
            _agent.speed = _grassSpeed;
        }
    }
}
