using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 6f;
    [SerializeField] float iceFriction = 2f;
    [SerializeField] MoveInputSource[] sources;

    [Header("Graphics")]
    [SerializeField] private Transform spriteTransform;
    [SerializeField] float rotationOffset = 90f;

    private Rigidbody2D rb;
    private MoveInputSource input;
    private Vector2 intent;

    private float boostMultiplier = 1f;
    private float boostTimerLeft;
    public bool IsActiveBoost => boostTimerLeft > 0;
    public float ReaminingBoostTime => boostTimerLeft;
    public float CurrentSpeed => baseSpeed * (boostTimerLeft > 0 ? boostMultiplier : 1f);


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = sources[(int)ControlSettings.Current];    
    }

    void Update()
    {
        intent = input.ReadIntent();
        if (boostTimerLeft > 0)
            boostTimerLeft -= Time.deltaTime;

        if(intent != Vector2.zero && spriteTransform != null)
        {
            float angle = Mathf.Atan2(intent.y, intent.x) * Mathf.Rad2Deg;
            spriteTransform.rotation = Quaternion.Euler(0, 0, angle + rotationOffset);
        }
    }
    
    

    void FixedUpdate()
    {
        Vector2 targetVelocity = intent * CurrentSpeed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, Time.fixedDeltaTime * iceFriction);
    }

    public void ApplySpeedBoost(float multipler, float duration)
    {
        boostMultiplier = multipler;
        boostTimerLeft = duration;
    }
}
