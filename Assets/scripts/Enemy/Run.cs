using UnityEngine;
using UnityEngine.AI;

public class Run : MoveEnemy
{
    [SerializeField] private NavMeshAgent _agent;
    public override void Start()
    {
        base.Start();
        SetMinDistance(_agent.stoppingDistance);
    }
    private void SetDestination(Transform point)
    {
        _agent.SetDestination(point.position);
    }

    public override void Update()
    {
        base.Update();
        if (IsRunning)
        {
            SetDestination(Player);
        }
    }
}
