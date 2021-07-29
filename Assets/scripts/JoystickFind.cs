using UnityEngine;

public class JoystickFind : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    public static JoystickFind singltonJoystick;
    void Start()
    {
        singltonJoystick = this;
    }
    public Joystick GetJoystick()
    {
        return _joystick;
    }


}
