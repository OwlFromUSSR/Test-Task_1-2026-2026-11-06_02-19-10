using UnityEngine;
using TMPro;

public class ScoreHUD : MonoBehaviour
{
    [SerializeField] ScoreManager score;
    [SerializeField] TMP_Text scoreText, multiplierText;

    private int shownScore = -1;
    private float shownPercent = -1f;

    private void Update()
    {
        if(score.Score != shownScore)
        {
            shownScore = score.Score;
            scoreText.text = shownScore.ToString("N0");
        }

        float p = score.MultiplierPercent;
        if (!Mathf.Approximately(p, shownPercent))
        {
            shownPercent = p;
            multiplierText.text = $"x{p / 100f:0.00}";
        }
    }
}
