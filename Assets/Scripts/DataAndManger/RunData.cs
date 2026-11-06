using UnityEngine;

public static class RunData 
{
    const string LastScoreKey = "LastRunScore";
    const string BestScoreKey = "BestRunScore";

    public static int LastScore => PlayerPrefs.GetInt(LastScoreKey, 0);
    public static int BestScore => PlayerPrefs.GetInt(BestScoreKey, 0);

    public static void SaveRun(int score)
    {
        PlayerPrefs.SetInt(LastScoreKey, score);
        if (score > BestScore)
            PlayerPrefs.SetInt(BestScoreKey, score);

        PlayerPrefs.Save();
    }
}
