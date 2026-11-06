using UnityEngine;

public class SpeedPickup : Pickups
{
    protected override void Apply(PlayerMovement player) =>
        player.GetComponent<SpeedBoost>().Activate();

}
