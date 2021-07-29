using UnityEngine;



public class EnemyShoot : Shooting
{
    [SerializeField] private MoveEnemy _moveEnemy;
    private Transform _player;
    private float _maxDistance;
    public override void Start()
    {
        base.Start();
        _player = MovePlayer.MovePlayerSingleton.transform;
        _maxDistance = _moveEnemy.GetMaxDistance();
    }
    private void Update()
    {
       if(_moveEnemy.IsRunning == false)
        {
         
            if (_moveEnemy.CurrentDistance < _maxDistance)
            {
                RayCast<MovePlayer>(_player);
            }
        }
    }
    public override void RayCast<T>(Transform diraction)
    {
        base.RayCast<T>(diraction);
    }
}
