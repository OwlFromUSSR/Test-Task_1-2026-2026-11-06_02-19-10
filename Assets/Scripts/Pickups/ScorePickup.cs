using UnityEngine;

public class ScorePickup : Pickups
{
    [SerializeField] float scoreCount = 1500f;
    protected override void Apply(PlayerMovement player) =>
        ScoreManager.Instance.AddPoints(scoreCount);
}
