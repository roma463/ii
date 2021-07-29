using UnityEngine;

public class collision : MonoBehaviour
{
    public float Health{ private set; get; }
    public virtual void Start()
    {
        Health = 100;
    }
    public virtual void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.TryGetComponent(out BulletMove bullet))
        {
            Damege(bullet.GetDamege());
            bullet.offObject();
        }
    }
    private void Damege(int value)
    {
        print($"{Health}, {value}");
        Health -= value;
    }
   
}
