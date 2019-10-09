using UnityEngine;

public class PlayerMovement : Movement
{
    private void Update()
    {
        if (isMovementEnabled)
        {
            if (Input.GetButton("Fire1"))
            {
                navMeshAgent.isStopped = false;
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
        }

    }
}
