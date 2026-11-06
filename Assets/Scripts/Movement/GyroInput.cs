using UnityEngine;
using UnityEngine.InputSystem;

public class GyroInput : MoveInputSource
{
    [SerializeField] float sensivity = 2f;

    private void OnEnable()
    {
        if (Accelerometer.current != null)
            InputSystem.EnableDevice(Accelerometer.current);
    }
    
    private void OnDisable()
    {
        if (Accelerometer.current != null)
            InputSystem.DisableDevice(Accelerometer.current);
    }

    public override Vector2 ReadIntent()
    {
        Vector2 result;

        if (Accelerometer.current == null)
            result = Vector2.zero;
        else
        {
            Vector3 accel = Accelerometer.current.acceleration.ReadValue();
            Vector2 tilt = new Vector2(accel.x, accel.y);

            result = Vector2.ClampMagnitude(tilt * sensivity, 1f);
        }


        return result;
    }
}
