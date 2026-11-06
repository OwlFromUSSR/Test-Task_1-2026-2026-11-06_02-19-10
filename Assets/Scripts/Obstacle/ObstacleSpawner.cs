using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Obstacle prefab;
    [SerializeField] BoxCollider2D field;
    [SerializeField] Transform player;
    [SerializeField] float startInterval = 2.5f;
    [SerializeField] float minIntervalToSpawn = 0.6f;
    [SerializeField] float secondsToSpawnCap = 60f;
    [SerializeField] int maxOnScreen = 10;
    [SerializeField] float minDistanceToPlayer = 2.5f;

    private float timer, elapsed;
    private const int countTriesToSpawn = 10;

    void Update()
    {
        elapsed += Time.deltaTime;
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {

            timer = Mathf.Lerp(startInterval, minIntervalToSpawn, Mathf.Clamp01(elapsed / secondsToSpawnCap));

            if (Obstacle.Count < maxOnScreen
                && TryGetSpawnPoint(out var pos))
                Instantiate(prefab, pos, Quaternion.identity);
        }
    }

    private bool TryGetSpawnPoint(out Vector2 pos)
    {
        bool res = false;

        Bounds b = field.bounds;
        pos = default;

        int i = 0;
        while (!res && i < countTriesToSpawn)
        {
            pos = new Vector2(Random.Range(b.min.x, b.max.x), Random.Range(b.min.y, b.max.y));

            if (Vector2.Distance(pos, player.position) >= minDistanceToPlayer)
                res = true;
            else
                ++i;
        }

        return res;
    }

}
