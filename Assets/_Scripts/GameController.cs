using UnityEngine;

public static class GameController
{
    private static int score;

    public static bool IsGameOver { get; set; } = false;
    public static bool IsGoodGame
    {
        get { return score >= 5; } // ou o critério que você quiser
    }

    public static void Init()
    {
        score = 0;
        IsGameOver = false;
    }

    public static void AddScore()
    {
        score++;
    }

    public static void Burn()
    {
        score -= 10;
    }

    public static int GetScore()
    {
        return score;
    }

}
