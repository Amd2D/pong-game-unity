using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        {
            // Singleton to avoid having multiple game managers when loading the same scene
            if (GameManager.instance != null)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }
    }
    public int Player1Score = 0;
    public int Player2Score = 0;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public GameObject Ball;

    void Start()
    {
        Ball = GameObject.FindGameObjectWithTag("ball");
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

    private void OnGUI()
    {
        if (Player1Score == 10)
        {
            Player1Score = 0;
            Player2Score = 0;
        }
        else if (Player2Score == 10)
        {
            Player1Score = 0;
            Player2Score = 0;
        }
    }
}
