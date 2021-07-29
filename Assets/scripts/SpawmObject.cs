using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(DelayAtStart))]
public class SpawmObject : MonoBehaviour
{
    [SerializeField] private Transform _ground;
    [SerializeField] private GameObject _prefabPlayer;
    [SerializeField] private GameObject[] _prefabEnemy;
    [SerializeField] private LayerMask _mask;
    private Vector3 _leftUpPosition, _rightDownPosition;
    private DelayAtStart _delayAtStart;
    private void Awake()
    {
        _delayAtStart = GetComponent<DelayAtStart>();
    }
    private void Start()
    {
        var playerShoot = SpawnPlayer();

        var scaleGround = _ground.localScale.x;
        _leftUpPosition = _ground.position + new Vector3(scaleGround/2, 0, scaleGround/2);
        _rightDownPosition = _ground.position + new Vector3(-scaleGround/2, 0, _leftUpPosition.z - scaleGround/3*2);
        SpawnEnemy(playerShoot);


    }
    private PlayerShoot SpawnPlayer()
    {
        var playerPosition = -Vector3.forward * _ground.localScale.x / 2;
        var player = SpawnObject(_prefabPlayer, playerPosition);
        _delayAtStart.Add<MovePlayer>(player);
        return player.GetComponent<PlayerShoot>();
    }
    private void SpawnEnemy(PlayerShoot player)
    {
         for (int i = 0; i < _prefabEnemy.Length; i++)
        {
             for (int k = 0; k < 3; k++)
             {
                 var newEnemy = SpawnObject(_prefabEnemy[i], RandomPosition());
                 player.AddEnemy(newEnemy);
                 _delayAtStart.Add<MoveEnemy>(newEnemy);
             }
        }
    }
    private Vector3 RandomPosition()
    {
        var position = new Vector3(Random.Range(_leftUpPosition.x, _rightDownPosition.x), 0, Random.Range(_leftUpPosition.z, _rightDownPosition.z));
        NavMesh.SamplePosition(position, out NavMeshHit hit, 100, _mask);
        return hit.position;
    }
    private GameObject SpawnObject(GameObject spawnObj, Vector3 transformObj)
    {
       return Instantiate(spawnObj, transformObj, Quaternion.identity);
    }
}
