using UnityEngine;

namespace AirborneBall.Attach
{
    using PlayerInput;
    public class AttachController : MonoBehaviour
    {
        [SerializeField] private PlayerInputManager _playerInput;
        [SerializeField] private Transform _player;
        [SerializeField] private AttachPresentor _attachPresentor;
        [SerializeField] private LayerMask _layerStick;
        [SerializeField] private float _speedMove;

        private Collider2D _hitCollider;
        private Transform _stickySphere;
        private float _distanceCanStick = 0.75f;

        private void Start()
        {
            _playerInput.OnClickPlayer += CheckTouch;
        }

        private void OnDestroy()
        {
            _playerInput.OnClickPlayer -= CheckTouch;
        }

        private void FixedUpdate()
        {
            if (_stickySphere != null)
                Move();
        }

        private void Update()
        {
            if (_stickySphere != null)
            {
                if (!CheckCanAttachSphere(_stickySphere.position))
                {
                    _stickySphere = null;
                    _attachPresentor.Shpere = null;
                }
            }
        }

        private void CheckTouch(Vector3 placeClick)
        {
            _hitCollider = Physics2D.OverlapPoint(placeClick, _layerStick);

            if (_hitCollider == null)
                return;

            if (CheckCanAttachSphere(_hitCollider.transform.position))
            {
                _stickySphere = _hitCollider.transform;
                _attachPresentor.Shpere = _stickySphere;
            }
        }

        private void Move()
        {
            if (Mathf.Abs(_player.position.x - _stickySphere.position.x) < 0.05f)
                return;

            _player.position += (_player.position.x > _stickySphere.position.x ? Vector3.left : Vector3.right) * _speedMove * Time.fixedDeltaTime;
        }

        private bool CheckCanAttachSphere(Vector3 sphere) => _player.position.y + _distanceCanStick <= sphere.y;

    }
}
