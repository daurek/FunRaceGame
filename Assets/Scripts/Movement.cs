using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private Transform goal;
    public NavMeshAgent navMeshAgent;
    public bool isMovementEnabled { get; set; }

    public void SetGoal(Transform _goal)
    {
        goal = _goal;
        navMeshAgent.SetDestination(goal.position);
        navMeshAgent.isStopped = true;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
        navMeshAgent.SetDestination(goal.position);
        navMeshAgent.isStopped = true;
        isMovementEnabled = true;
    }
}
