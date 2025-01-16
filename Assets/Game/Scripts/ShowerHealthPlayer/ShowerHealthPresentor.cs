using UnityEngine;
using DG.Tweening;

namespace AirborneBall.ShowerHealthPlayer
{
    public class ShowerHealthPresentor : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hearts;

        public void IncreaseHealth(int indexHealth)
        {
            _hearts[indexHealth].transform.DOScale(Vector3.one, 1f);
        }

        public void DecreaseHealth(int indexHealth)
        {
            _hearts[indexHealth].transform.DOScale(Vector3.zero, 1f);
        }
    }
}
