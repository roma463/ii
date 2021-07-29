using UnityEngine;

public class Flying : MoveEnemy
{
    [SerializeField] private float _positionY;
    [SerializeField] private float _speed;

    public override void Start()
    {
        base.Start();
        var position  = transform.position;
        position.y = _positionY;
        transform.position = position;
    }

    public override void Update()
    {
        base.Update();
        if (IsRunning)
            Move();
    }
    private void Move()
    {
       
        var position = transform.position;
        position.z = Mathf.MoveTowards(transform.position.z, Player.position.z, _speed * Time.deltaTime);
        position.x = Mathf.MoveTowards(transform.position.x, Player.position.x, _speed * Time.deltaTime);
        transform.position = position;
    }
}
