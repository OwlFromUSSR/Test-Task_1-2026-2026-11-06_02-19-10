using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }

    [SerializeField] PlayerHealth health;
    [SerializeField] SpeedBoost boost;
    [SerializeField] float passivePerSecond = 75f;
    [SerializeField] float maxHealthFactor = 2f;

    float score;
    private float bonusPerLostHP => (maxHealthFactor - 1f) / (health.MaxHP - 1f);
    public int Score => Mathf.FloorToInt(score);
    public float SpeedFactor => boost.ScoreFactor;
    public float HealthFactor => Mathf.Min(maxHealthFactor, 1f + health.LostHP * bonusPerLostHP);
    public float MultiplierPercent => SpeedFactor * HealthFactor * 100f;
    public float Multiplier => MultiplierPercent / 100f;

    private void Awake() => Instance = this;

    private void Update()
    {
        if (!health.IsDead)
            AddPoints(passivePerSecond * Time.deltaTime);
    }

    public void AddPoints(float baseScore) => score += baseScore * Multiplier;

}
