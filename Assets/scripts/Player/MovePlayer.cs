using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour, ActiveComponent
{
    [SerializeField] private float _speed;
    [SerializeField] private NavMeshAgent _agent;
    private Joystick _joystick;
    private bool _activeDo = false;
    public static MovePlayer MovePlayerSingleton { private set; get; }
    public bool _isRunning { private set; get; }

    public void Active()
    {
        _activeDo = true;
    }

    private void Start()
    {
        MovePlayerSingleton = this;
        _agent.speed = _speed;
        _joystick = JoystickFind.singltonJoystick.GetJoystick();
    }
    private void Update()
    {
        if (!_activeDo)
            return;
        var moveDiraction = new Vector3(_joystick.Direction.x,0, _joystick.Direction.y);
        if (moveDiraction != Vector3.zero)
        {
            _isRunning = true;
            var dastination = moveDiraction + transform.position;
            _agent.SetDestination(dastination);
        }
        else
        {
            _isRunning = false;
            _agent.SetDestination(transform.position);
        }
    }
}
