using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Player1Score = 0;
    public int Player2Score = 0;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Ball;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text Player1WinsText;
    public Text Player2WinsText;
    public Text NewGameText;

    public static GameManager instance;
    private void Awake()
    {
        {
            if (GameManager.instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }
        Player1WinsText.gameObject.SetActive(false);
        Player2WinsText.gameObject.SetActive(false);
        NewGameText.gameObject.SetActive(false);
    }

    public void Score(string wall)
    {
        if (wall == "left_wall")
        {
            Player2Score++;
            player2ScoreText.text = Player2Score.ToString();
        }
        else if (wall == "right_wall")
        {
            Player1Score++;
            player1ScoreText.text = Player1Score.ToString();
        }
    }

    private void Update()
    {
        ResetGame();
        GameOver();
    }

    private void ResetGameState()
    {
        Player1Score = 0;
        Player2Score = 0;
        player1ScoreText.text = "0";
        player2ScoreText.text = "0";
        Player1.transform.position = new Vector2(-8, 0);
        Player2.transform.position = new Vector2(8, 0);
        Player1WinsText.gameObject.SetActive(false);
        Player2WinsText.gameObject.SetActive(false);
        NewGameText.gameObject.SetActive(false);
        Ball.gameObject.SetActive(true);
    }

    private void ResetGame()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ResetGameState();
            Ball.SendMessage("StartMatch", null, SendMessageOptions.RequireReceiver);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            ResetGameState();
            Ball.SendMessage("StartMatch", null, SendMessageOptions.RequireReceiver);
        }
    }

    private void GameOver()
    {
        if (Player1Score == 2)
        {
            Player1WinsText.gameObject.SetActive(true);
            NewGameText.gameObject.SetActive(true);
            Ball.gameObject.SetActive(false);
            ResetGame();
        }
        else if (Player2Score == 2)
        {
            Player2WinsText.gameObject.SetActive(true);
            NewGameText.gameObject.SetActive(true);
            Ball.gameObject.SetActive(false);
            ResetGame();
        }
    }
}
