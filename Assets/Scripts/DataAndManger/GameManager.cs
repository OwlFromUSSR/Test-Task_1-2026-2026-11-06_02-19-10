using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerHealth health;
    [SerializeField] ScoreManager score;
    [SerializeField] GameObject deathPanel;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] Button gyroButton;

    private void Start()
    {
        Time.timeScale = 1f;
        deathPanel.SetActive(false);

        if (gyroButton != null)
            gyroButton.gameObject.SetActive(Accelerometer.current != null);

        health.Died += OnDied;
    }

    private void OnDestroy()
    {
        if (health != null)
            health.Died -= OnDied;
    }

    private void OnDied()
    {
        RunData.SaveRun(score.Score);

        finalScoreText.text = $"Очки: {score.Score:N0}\nРекорд: {RunData.BestScore:N0}";
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartWithControl(int style)
    {
        ControlSettings.Current = (ControlStyle)style;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
