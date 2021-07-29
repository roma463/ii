using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delayOff;
    [SerializeField] private int _damege;
    [SerializeField] private BoxCollider _boxCollider;
    public void IgnoreCollider(BoxCollider collider)
    {
        Physics.IgnoreCollision(_boxCollider, collider);
    }
    public int GetDamege()
    {
        return _damege;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        Invoke(nameof(offObject), _delayOff);
    }
    public void offObject()
    {
        gameObject.SetActive(false);
    }
}
