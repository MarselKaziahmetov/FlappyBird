using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    private Text scoreText;

    private static int scoreCounter;
    private static int highScoreCounter;

    private void OnEnable()
    {
        EventBus.OnScoreUpdated += UpdateScore;
        EventBus.OnHighScoreUpdated += UpdateHighScore;
    }

    private void OnDisable()
    {
        EventBus.OnScoreUpdated -= UpdateScore;
        EventBus.OnHighScoreUpdated -= UpdateHighScore;
    }

    void Start()
    {
        scoreText = GetComponent<Text>();

        scoreCounter = 0;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCounter = PlayerPrefs.GetInt("HighScore");
        }
    }

    void UpdateScore()
    {
        scoreText.text = scoreCounter.ToString();
    }
    
    void UpdateHighScore()
    {
        highScoreText.text = highScoreCounter.ToString();
    }

    public static void AddScore()
    {
        scoreCounter++;
        AudioHandler.Instance.ScoreSoundPlay();

        EventBus.OnScoreUpdated?.Invoke();
    } 

    public static void SetNewHighScore()
    {
        if (scoreCounter > highScoreCounter)
        {
            highScoreCounter = scoreCounter;
            PlayerPrefs.SetInt("HighScore", highScoreCounter);
        }

        EventBus.OnHighScoreUpdated?.Invoke();
    }
}
