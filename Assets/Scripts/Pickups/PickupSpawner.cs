using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] Pickups[] prefabs;
    [SerializeField] BoxCollider2D field;
    [SerializeField] float interval = 4f;
    [SerializeField] int maxOnField = 4;

    private float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer = interval;
            if(Pickups.Count < maxOnField)
            {
                Bounds b = field.bounds;

                Vector2 pos = new Vector2(Random.Range(b.min.x, b.max.x),
                                          Random.Range(b.min.y, b.max.y));
                Instantiate(prefabs[Random.Range(0, prefabs.Length)], pos, Quaternion.identity);
            }
        }
    }
}
