using UnityEngine;

namespace AirborneBall.Obstacle.Heal
{
    using HealthSystem;
    using Obstacle;

    public class HealthObstacleController : ObstacleController
    {
        [SerializeField] private int _healthPoint = 1;

        private HealthSystemController _player;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out _player))
            {
                _player.Health(_healthPoint);
                gameObject.SetActive(false);
            }
        }
    }
}
