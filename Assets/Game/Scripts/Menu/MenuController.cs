using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AirborneBall.Menu
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private int _indexGameScene;

        private void Awake()
        {
            _startButton.onClick.AddListener(LoadScene);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(LoadScene);
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(_indexGameScene);
        }
    }
}
