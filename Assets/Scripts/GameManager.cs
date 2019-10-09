using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Game References")]
    public Player[] players;
    public Goal goal;

    [Header("UI References")]
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI winnerText;
    public GameObject gamePanel;

    private float countdown;
    private float baseCountdown = 0;
    private bool isRaceOn;

    private void Awake()
    {
        goal.SetGameManagerRef(this);
        countdown = baseCountdown;

        for (int i = 0; i < players.Length; i++)
        {
            Player player = players[i];
            player.movement.SetGoal(goal.transform);
            player.state.SetCheckpoint(player.state.transform.position);
        }
    }

    private void Update()
    {
        if (!isRaceOn)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.CeilToInt(countdown).ToString();

            if (countdown <= 0)
            {
                countdownText.text = "GO!";
                StartRace();
                Invoke("HideText", 4);
            }
        }

    }

    public void StartRace()
    {
        for (int i = 0; i < players.Length; i++)
        {
            Player player = players[i];
            player.movement.isMovementEnabled = true;
        }
        isRaceOn = true;
    }

    public void SetWinner(State _State)
    {
        gamePanel.SetActive(true);
        Time.timeScale = 0;
        if (_State.playerIndex == 0)
        {
            // Player won
            winnerText.text = "You won! :)";
        }
        else
        {
            // Player lost
            winnerText.text = "You lost! :(";
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void HideText()
    {
        countdownText.gameObject.SetActive(false);
    }

}

[System.Serializable]
public struct Player
{
    public Movement movement;
    public State state;
}
