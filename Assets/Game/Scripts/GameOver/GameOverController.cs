using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AirborneBall.GameOver
{
    using HealthSystem;
    using Interacts;
    public class GameOverController : MonoBehaviour, IInitializable<HealthSystemController>
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _menuGameOver;
        
        private HealthSystemController _healthSystem;

        public void Init(HealthSystemController data)
        {
            _healthSystem = data;
            _healthSystem.OnDeath += OpenGameOverPanel;
        }

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartLevel);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.RemoveListener(RestartLevel);
            _healthSystem.OnDeath -= OpenGameOverPanel;
        }

        private void OpenGameOverPanel()
        {
            _menuGameOver.SetActive(true);
        }

        private void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
