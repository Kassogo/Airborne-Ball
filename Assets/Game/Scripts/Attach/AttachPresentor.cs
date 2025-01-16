using UnityEngine;

namespace AirborneBall.Attach
{
    public class AttachPresentor : MonoBehaviour
    {
        public Transform Shpere
        {
            set
            {
                _lineRenderer.enabled = value != null;
                _shpere = value;
            }
        }

        [SerializeField] private LineRenderer _lineRenderer;
        private Transform _shpere;


        private void Awake()
        {
            if (!TryGetComponent(out _lineRenderer))
                Debug.LogError("LineRenderer not found!");
            else
                _lineRenderer.enabled = false;
        }

        private void Update()
        {
            if (_shpere == null || _lineRenderer == null)
                return;

            ShowLine();
        }

        private void ShowLine()
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _shpere.position);
        }
    }
}
