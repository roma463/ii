using UnityEngine;

public class PlayerCollision : collision
{
    private Ui _ui;
    public override void Start()
    {
        base.Start();
        _ui = Ui.UiGlobal;
    }
    public override void OnTriggerEnter(Collider collision)
    {
        base.OnTriggerEnter(collision);
        if(Health <= 0)
        {
            Death();
        }
        if(collision.gameObject.tag == "Finish")
        {
            _ui.Finish();
        }
    }
    private void Death()
    {
        gameObject.SetActive(false);
        _ui.Death();
    }
}
