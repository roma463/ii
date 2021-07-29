using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private BulletMove _bullet;
    [SerializeField] private float _delayShoot;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private BoxCollider _boxCollider;
    private bool _isShoot = true;
    private List<GameObject> _bullets = new List<GameObject>();
    private Transform _diraction;
    public virtual void Start()
    {
        for (int i = 0; i < 15; i++)
        {
         BulletMove spawnObject = Instantiate(_bullet, transform.position, Quaternion.identity);
            spawnObject.IgnoreCollider(_boxCollider);
            spawnObject.gameObject.SetActive(false);
            _bullets.Add(spawnObject.gameObject);
        }
    }
    private void IsShoot()
    {
        if (_isShoot)
            StartCoroutine(nameof(ShootDelay));
    }
    private Vector3 ShootDiraction()
    {
        return transform.eulerAngles;
    }
    private void ActiveBullet()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            var currentBullet = _bullets[i];
            if (_bullets[i].activeInHierarchy == false)
            {
                currentBullet.SetActive(true);
                currentBullet.transform.position = transform.position;
                currentBullet.transform.LookAt(_diraction);
                break;
            }
        }  
    }
    public virtual void RayCast<T>(Transform diraction)
    {
        _diraction = diraction;
        RaycastHit hit;
        Ray ray = new Ray(transform.position, (diraction.position - transform.position).normalized);
        if (Physics.Raycast(ray, out hit, 50, _mask))
        {
            if (hit.collider.gameObject.TryGetComponent(out T moveEnemy))
            IsShoot();
        }
    }
    private IEnumerator ShootDelay()
    {
        _isShoot = false;
        ActiveBullet();
        yield return new WaitForSeconds(_delayShoot);
        _isShoot = true;
    }
}
