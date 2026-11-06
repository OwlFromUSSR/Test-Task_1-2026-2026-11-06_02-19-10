using UnityEngine;
using UnityEngine.InputSystem;
public class KeyboardInput : MoveInputSource
{
    public override Vector2 ReadIntent()
    {
        Vector2 result;

        if (Keyboard.current == null)
            result = Vector2.zero;
        else
        {
            float x = (Keyboard.current.dKey.isPressed ? 1f : 0f)
                      - (Keyboard.current.aKey.isPressed ? 1f : 0f);
            float y = (Keyboard.current.wKey.isPressed ? 1f : 0f)
                      - (Keyboard.current.sKey.isPressed ? 1f : 0f);

            result = Vector2.ClampMagnitude(new Vector2(x, y), 1f);
        }
        return result;
    }
}
