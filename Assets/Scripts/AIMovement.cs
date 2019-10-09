using UnityEngine;

public class AIMovement : Movement
{

    public Transform lowerDetector;
    public Transform middleDetector;


    private void Update()
    {
        if (isMovementEnabled)
        {
            RaycastHit raycastHit;

            if (Physics.Linecast(transform.position, lowerDetector.position, out raycastHit))
            {
                CheckObstacle(raycastHit.collider.GetComponent<Obstacle>());
            }
            else if (Physics.Linecast(transform.position, middleDetector.position, out raycastHit))
            {
                CheckObstacle(raycastHit.collider.GetComponent<Obstacle>());
            }
            else
            {
                navMeshAgent.isStopped = false;
            }
        }
    }

    private void CheckObstacle(Obstacle obstacle)
    {
        if (obstacle)
        {
            navMeshAgent.isStopped = true;
        }
        else
        {
            navMeshAgent.isStopped = false;
        }
    }
}
