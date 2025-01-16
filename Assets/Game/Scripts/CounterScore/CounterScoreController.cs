using UnityEngine;
using TMPro;

namespace AirborneBall.CounterScore
{
    using HealthSystem;
    using Interacts;
    public class CounterScoreController : MonoBehaviour, IInitializable<HealthSystemController>
    {
        [SerializeField] private float _speedAddScore;
        [SerializeField] private TextMeshProUGUI _textScore;

        private HealthSystemController _healthSystem;
        private float _score = 0;
        private bool _isDead = false;

        public void Init(HealthSystemController data)
        {
            _healthSystem = data;
            _healthSystem.OnDeath += Death;
        }

        private void OnDestroy()
        {
            _healthSystem.OnDeath -= Death;
        }

        private void Update()
        {
            if (_isDead)
                return;

            AddScore();
        }

        private void AddScore()
        {
            _score += _speedAddScore * Time.deltaTime;

            _textScore.text = "SCORE\n" + (int)_score;
        }

        private void Death() => _isDead = true;
    }
}
