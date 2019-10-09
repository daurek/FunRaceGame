using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<State>().SetCheckpoint(transform.position);
        }
    }
}
