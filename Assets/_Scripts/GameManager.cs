using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI endGameText;
    public GameObject endGamePanel;

    private float elapsedTime = 0f;
    private int lives = 3;
    private bool gameEnded = false;

    void Start()
    {
        GameController.Init();
        UpdateUI();
        endGamePanel.SetActive(false);
    }

    void Update()
    {
        if (GameController.IsGameOver && !gameEnded)
        {
            EndGame();
            return;
        }

        if (!gameEnded)
        {
            elapsedTime += Time.deltaTime;
            UpdateUI();
        }
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            GameController.IsGameOver = true;
        }
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {GameController.GetScore()}";
        livesText.text = $"Vidas: {lives}";
        timeText.text = $"Tempo: {elapsedTime:F1}s";
    }

    private void EndGame()
    {
        gameEnded = true;
        endGamePanel.SetActive(true);

        float highScore = PlayerPrefs.GetFloat("HighScoreTime", 0f);
        if (elapsedTime > highScore)
        {
            highScore = elapsedTime;
            PlayerPrefs.SetFloat("HighScoreTime", highScore);
        }

        endGameText.text = $"Tempo final: {elapsedTime:F1}s\nMelhor tempo: {highScore:F1}s";
    }
}
