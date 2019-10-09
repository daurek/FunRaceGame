using UnityEngine;

public class Obstacle : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<State>().Defeat();
        }
    }

}
