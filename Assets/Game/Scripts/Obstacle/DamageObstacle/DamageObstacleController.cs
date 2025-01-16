using UnityEngine;

namespace AirborneBall.Obstacle.Damage
{
    using HealthSystem;
    using Obstacle;

    public class DamageObstacleController : ObstacleController
    {
        [SerializeField] private int _damage = 1;

        private HealthSystemController _player;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out _player))
            {
                _player.Damage(_damage);
                gameObject.SetActive(false);
            }
        }
    }
}
