using UnityEngine;

public enum ControlStyle { Keyboard, Joystick, Gyro}

public static class ControlSettings
{
    const string Key = "ControlStyle";
    
    public static ControlStyle Current
    {
        get => (ControlStyle)PlayerPrefs.GetInt(Key, 0);
        set { PlayerPrefs.SetInt(Key, (int)value); PlayerPrefs.Save(); }
    }
}
