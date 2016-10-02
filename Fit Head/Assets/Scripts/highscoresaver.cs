using UnityEngine;

public class ScoreManager
{
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore " + PlayerPrefs.GetString("Level Difficulty"));
    }

    // Will set the score as the high score if it is the new high score
    public static int TrySetHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore " + PlayerPrefs.GetString("Level Difficulty"), Mathf.Max(GetHighScore(), score));
        return Mathf.Max(GetHighScore(), score);
    }
}

