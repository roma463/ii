using UnityEngine;
using UnityEngine.AI;

public class MoveEnemy : MonoBehaviour, ActiveComponent
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minDistance;
    private bool _activeDo = false;
    public Transform Player { private set; get; }
    public bool IsRunning { private set; get; }
    public float CurrentDistance { private set; get; }
    public virtual void Start()
    {
        Player = MovePlayer.MovePlayerSingleton.transform;
    }
    public void SetMinDistance(float value)
    {
        _minDistance = value;
    }
    public float GetMaxDistance()
    {
        return _maxDistance;
    }

    public virtual void Update()
    {
        CurrentDistance = Vector3.Distance(Player.position, transform.position);

        if (!_activeDo)
            return;
        if (Player != null)
        {
            if(CurrentDistance < _maxDistance 
                && CurrentDistance > _minDistance)
            {
                IsRunning = true;
            }
            else
            {
                IsRunning = false;
            }
        }
    }

    public void Active()
    {
        _activeDo = true;
    }
}
