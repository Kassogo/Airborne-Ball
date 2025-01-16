using System.Collections.Generic;
using UnityEngine;

namespace AirborneBall.LevelFabric
{
    using HealthSystem;
    using Interacts;

    public class LevelFabricController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Transform _spawnPointPlayer;
        [SerializeField] private List<GameObject> _initsHealthSystem;

        private HealthSystemController _healthSystemPlayer;
        private IInitializable<HealthSystemController> _initHealth;
        private GameObject _createdPlayer;

        private void Awake()
        {
            _createdPlayer = Instantiate(_player, _spawnPointPlayer.position, Quaternion.identity);
            FindHealthSystem();

            if (_healthSystemPlayer == null)
                Debug.LogError("Not found Health System Player!");

            InitHealthSystem();
        }

        private void FindHealthSystem()
        {
            for (int i = 0; i < _createdPlayer.transform.childCount; i++)
            {
                if (_createdPlayer.transform.GetChild(i).TryGetComponent(out _healthSystemPlayer))
                    break;
            }
        }

        private void InitHealthSystem()
        {
            for (int i = 0; i < _initsHealthSystem.Count; i++)
            {
                if (_initsHealthSystem[i].TryGetComponent(out _initHealth))
                    _initHealth.Init(_healthSystemPlayer);
            }
        }
    }
}
