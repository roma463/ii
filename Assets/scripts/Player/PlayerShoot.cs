using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovePlayer))]
public class PlayerShoot : Shooting
{
    [SerializeField] private float _minDistanceShoot;
    private MovePlayer _movePlayer;
    private List<GameObject> _enemy = new List<GameObject>();
    private Transform _closestEnemy;
    public void AddEnemy(GameObject enemy)
    {
        _enemy.Add(enemy);
    }
    public override void Start()
    {
        _movePlayer = GetComponent<MovePlayer>();
        base.Start();
    }

    private void Update()
    {
        if (!_movePlayer._isRunning)
        {
           ClosestEnemy();
            if(_closestEnemy != null)
                RayCast<MoveEnemy>(_closestEnemy);
        }
    }
    private void ClosestEnemy()
    {
        var minDistance = _minDistanceShoot;
        Transform closest = null;
        for (int i = 0; i < _enemy.Count; i++)
        {
            var currentDistance = Vector3.Distance(_enemy[i].transform.position, transform.position);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                closest = _enemy[i].transform;
            }
        }
        _closestEnemy = closest;

    }
    public override void RayCast<T>(Transform enemy)
    {
         base.RayCast<T>(enemy);
    }
}
