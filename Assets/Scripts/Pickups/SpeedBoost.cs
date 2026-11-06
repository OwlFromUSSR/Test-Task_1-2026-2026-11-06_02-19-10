using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float moveFactor = 1.5f;
    [SerializeField] float scoreFactor = 1.5f;
    [SerializeField] float duration = 7f;

    [SerializeField] PlayerMovement player;
    private float remaining;

    public bool Active => player.IsActiveBoost;
    public float Remaining => player.ReaminingBoostTime;
    public float Duration => duration;
    public float ScoreFactor => Active ? scoreFactor : 1;

    public void Activate()
    {
        player.ApplySpeedBoost(scoreFactor, duration);
    }
}
