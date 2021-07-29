using UnityEngine;

public class enemyCollision : collision
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
        if (Health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        gameObject.SetActive(false);
        _ui.AddMoneu(10);
    }
}
