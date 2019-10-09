using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] cameraPath;

    private Transform currentPathPoint;
    private int pathTargetIndex;
    public PlayerMovement playerMovement;
    public PlayerState playerState;

    private void Start()
    {
        playerState.SetCameraControllerRef(this);
        NextPathPoint();
    }

    private void Update()
    {
        if (pathTargetIndex < cameraPath.Length - 1 && Vector3.Distance(transform.position, currentPathPoint.position) < 0.1f)
        {
            NextPathPoint();
        }

        if (!playerMovement.navMeshAgent.isStopped)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraPath[pathTargetIndex].position, 5 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, cameraPath[pathTargetIndex].rotation, Time.deltaTime * 0.3f);
        }
               
    }

    private void NextPathPoint()
    {
        currentPathPoint = cameraPath[++pathTargetIndex];
    }

    public void ResetToNearestPathPoint(Vector3 position)
    {
        int nearestPathPointIndex = 0;
        float closestDistanceSqr = Mathf.Infinity;
        int cameraPathLength = cameraPath.Length;
        for (int i = 0; i < cameraPathLength; i++)
        {
            Transform pathPoint = cameraPath[i];
            Vector3 directionToTarget = pathPoint.position - position;
            float distanceToTarget = directionToTarget.sqrMagnitude;
            if (distanceToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = distanceToTarget;
                nearestPathPointIndex = i;
            }
        }
        pathTargetIndex = nearestPathPointIndex;
        currentPathPoint = cameraPath[pathTargetIndex];
        transform.position = cameraPath[pathTargetIndex].position;
        transform.rotation = cameraPath[pathTargetIndex].rotation;
    }
}
