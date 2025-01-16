using UnityEngine;
using UnityEngine.UI;

namespace AirborneBall.ShowerHealthPlayer
{
    using HealthSystem;
    using Interacts;
    public class ShowerHealthController : MonoBehaviour, IInitializable<HealthSystemController>
    {
        [SerializeField] private ShowerHealthPresentor _healthPresentor;
        [SerializeField] private RectTransform _container;

        private HealthSystemController _healthSystem;
        private int _showingHealth;

        public void Init(HealthSystemController data)
        {
            _healthSystem = data; 
            _healthSystem.OnChangeHealth += ChangeHealth;
            _showingHealth = _healthSystem.CurrentHealth;
        }

        private void Start()
        {
            LayoutRebuilder.MarkLayoutForRebuild(_container);
        }

        private void OnDestroy()
        {
            _healthSystem.OnChangeHealth -= ChangeHealth;
        }

        private void ChangeHealth(int health)
        {
            if (health < _showingHealth)
                _healthPresentor.DecreaseHealth(health);
            else if(health > _showingHealth)
                _healthPresentor.IncreaseHealth(health - 1);

            _showingHealth = health;
        }
    }
}
