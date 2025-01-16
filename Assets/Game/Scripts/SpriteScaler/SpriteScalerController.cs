using UnityEngine;

namespace AirborneBall.SpriteScaler
{
    public class SpriteScalerController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            if (!TryGetComponent(out _spriteRenderer))
            {
                Debug.LogError("SpriteRenderer not found!");
                return;
            }

            Vector3 spriteSize = _spriteRenderer.sprite.bounds.size;
            Vector2 screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize * 2, Camera.main.orthographicSize * 2);
            Vector2 scale = screenSize / spriteSize;
            transform.localScale = new Vector3(scale.x, scale.y, 1);
        }
    }
}
