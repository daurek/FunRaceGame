using UnityEngine;

public class ObstacleLinecast : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Linecast(transform.position, transform.position + transform.forward * 10, out hitInfo))
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, hitInfo.distance));

            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<State>().Defeat();
            }
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(0, 0, 10));
        }
    }


}
