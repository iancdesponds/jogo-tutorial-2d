using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject goodGamePanel;
    public GameObject gameOverPanel;

    void Update()
    {
        if (GameController.IsGoodGame)
        {
            goodGamePanel.SetActive(true);
        }
        else if (GameController.IsGameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
