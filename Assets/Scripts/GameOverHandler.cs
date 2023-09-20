using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        ScoreManager.SetNewHighScore();
        
        Time.timeScale = 0;

        AudioHandler.Instance.BackgroundSoundPause();
        AudioHandler.Instance.DeathSoundPlay();
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
