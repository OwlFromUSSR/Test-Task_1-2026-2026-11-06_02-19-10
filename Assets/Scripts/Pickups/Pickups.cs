using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    [SerializeField] float lifetime = 10f;

    public static int Count { get; private set; }

    private void OnEnable() => ++Count;
    private void OnDisable() => --Count;

    private void Start() => Destroy(gameObject, lifetime);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            Apply(player);
            Destroy(gameObject);
        }
    }

    protected abstract void Apply(PlayerMovement player);
}
