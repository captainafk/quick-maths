using UnityEngine;

public static class SavedData
{
    public static int highScore = 0;

    public static void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
    }
}