using UnityEngine;

public class JoystickInput : MoveInputSource
{
    [SerializeField] private Joystick joystick;//добавить ссилку на UI компонент

    void Start()
    {
        bool isJoystickActive = ControlSettings.Current == ControlStyle.Joystick;

        if (joystick != null)
            joystick.gameObject.SetActive(isJoystickActive);

    }

    public override Vector2 ReadIntent()
    {
        Vector2 result;

        if (joystick == null || !joystick.gameObject.activeInHierarchy)
            result = Vector2.zero;
        else
            result = new Vector2(joystick.Horizontal, joystick.Vertical);

        return result;
    }

}
