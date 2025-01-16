using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace AirborneBall.Spawner
{
    using HealthSystem;
    using Obstacle;
    using Interacts;

    public class SpawnerObstacle : MonoBehaviour, IInitializable<HealthSystemController>
    {
        [SerializeField] private ObstacleController _stickyObstacle;
        [SerializeField] private int _stickyObstacleCountStart;
        [Space]
        [SerializeField] private ObstacleController _healthObstacle;
        [SerializeField] private int _healObstacleCountStart;
        [Space]
        [SerializeField] private ObstacleController _damageObstacle;
        [SerializeField] private int _damageObstacleCountStart;

        private HealthSystemController _healthSystem;

        private ObstacleController _chooseObstacle;
        private Vector3 _startSpawnPosition;
        private Vector3 _endSpawnPosition;
        private float _zPositionObject = -4.5f;

        private ObjectPool<ObstacleController> _poolStickyObstacles;
        private ObjectPool<ObstacleController> _poolDamageObstacles;
        private ObjectPool<ObstacleController> _poolHealObstacles;

        public void Init(HealthSystemController data)
        {
            _healthSystem = data;
        }

        private void Awake()
        {
            _poolStickyObstacles = new ObjectPool<ObstacleController>(() => Instantiate(_stickyObstacle),
                actionOnGet: (obstacle) => obstacle.gameObject.SetActive(true), actionOnRelease: (obstacle) => obstacle.gameObject.SetActive(false), maxSize: _stickyObstacleCountStart);
            _poolDamageObstacles = new ObjectPool<ObstacleController>(() => Instantiate(_damageObstacle),
                actionOnGet: (obstacle) => obstacle.gameObject.SetActive(true), actionOnRelease: (obstacle) => obstacle.gameObject.SetActive(false), maxSize: _damageObstacleCountStart);
            _poolHealObstacles = new ObjectPool<ObstacleController>(() => Instantiate(_healthObstacle),
                actionOnGet: (obstacle) => obstacle.gameObject.SetActive(true), actionOnRelease: (obstacle) => obstacle.gameObject.SetActive(false), maxSize: _healObstacleCountStart);

            _startSpawnPosition = Camera.main.ViewportToWorldPoint(Vector2.up);
            _endSpawnPosition = Camera.main.ViewportToWorldPoint(Vector2.one);
            _startSpawnPosition.z = _zPositionObject;
            _endSpawnPosition.z = _zPositionObject;
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (_healthSystem.CurrentHealth > 0)
            {
                GetRandomObstacle().transform.position = new Vector3(Random.Range(_startSpawnPosition.x, _endSpawnPosition.x), _startSpawnPosition.y, _zPositionObject);
                yield return new WaitForSeconds(Random.Range(0.1f, 1f));
            }
        }

        private ObstacleController GetRandomObstacle()
        {
            int randomChance = Random.Range(0, 100);

            if (randomChance < 80)
            {
                _chooseObstacle = _poolStickyObstacles.Get();
                _chooseObstacle.OnNotNeedObject += ReturnSticky;
            }
            else if (randomChance < 90)
            {
                _chooseObstacle = _poolHealObstacles.Get();
                _chooseObstacle.OnNotNeedObject += ReturnHeal;
            }
            else
            {
                _chooseObstacle = _poolDamageObstacles.Get();
                _chooseObstacle.OnNotNeedObject += ReturnDamage;
            }

            return _chooseObstacle;
        }

        private void ReturnSticky(ObstacleController obstacle)
        {
            obstacle.OnNotNeedObject -= ReturnSticky;
            _poolStickyObstacles.Release(obstacle);
        }

        private void ReturnHeal(ObstacleController obstacle)
        {
            obstacle.OnNotNeedObject -= ReturnHeal;
            _poolHealObstacles.Release(obstacle);
        }

        private void ReturnDamage(ObstacleController obstacle)
        {
            obstacle.OnNotNeedObject -= ReturnDamage;
            _poolDamageObstacles.Release(obstacle);
        }
    }
}
