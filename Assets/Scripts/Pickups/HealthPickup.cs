using UnityEngine;

public class HealthPickup : Pickups
{
    [SerializeField] int amount = 1;

    protected override void Apply(PlayerMovement player) =>
        player.GetComponent<PlayerHealth>().Heal(amount);
}
