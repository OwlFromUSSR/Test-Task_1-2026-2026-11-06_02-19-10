using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float lifeTime = 10;

    public static int Count { get; set; }

    private void OnEnable() => ++Count;
    private void OnDisable() => --Count;

    private void Start() => Destroy(gameObject, lifeTime);
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth hp))
            hp.TakeDamage(damage);
    }
}
