using System;
using UnityEngine;

namespace AirborneBall.HealthSystem
{
    public class HealthSystemController : MonoBehaviour
    {
        public event Action<int> OnChangeHealth = delegate { };
        public event Action OnDeath = delegate { };

        public int CurrentHealth => _currentHealth;

        [SerializeField] private int _maxHealth;

        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void Damage(int damagePoint)
        {
            _currentHealth -= damagePoint;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                OnDeath.Invoke();
            }

            OnChangeHealth.Invoke(_currentHealth);
        }

        public void Health(int healhPoint)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + healhPoint, 0, _maxHealth);
            OnChangeHealth.Invoke(_currentHealth);
        }
    }
}
