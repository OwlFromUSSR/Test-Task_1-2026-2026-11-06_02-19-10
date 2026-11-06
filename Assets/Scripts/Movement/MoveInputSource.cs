using UnityEngine;

public abstract class MoveInputSource : MonoBehaviour
{
    public abstract Vector2 ReadIntent();
}
