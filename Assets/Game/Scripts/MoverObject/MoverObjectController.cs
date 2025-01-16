using UnityEngine;

namespace AirborneBall.MoverController
{
    public class MoverObjectController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            transform.position += Vector3.down * _speed * Time.fixedDeltaTime;
        }
    }
}
