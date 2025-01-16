using UnityEngine;
using DG.Tweening;

namespace AirborneBall.CreatedAnimation
{
    public class AnimationPulsating : MonoBehaviour
    {
        [SerializeField] private Vector3 _generalSize = Vector3.one;
        [SerializeField] private Vector3 _finalSize = new Vector3(1.1f, 1.1f, 1.1f);

        private Sequence _sequence;
        private void Start()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_finalSize, 2));
            _sequence.Append(transform.DOScale(_generalSize, 2));
            _sequence.SetEase(Ease.Linear);
            _sequence.SetLoops(-1);
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}
