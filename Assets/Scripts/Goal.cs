using UnityEngine;

public class Goal : MonoBehaviour
{
    private GameManager gameManagerRef;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameManagerRef.SetWinner(collision.collider.GetComponent<State>());
        }
    }

    public void SetGameManagerRef(GameManager gameManager)
    {
        gameManagerRef = gameManager;
    }
}
