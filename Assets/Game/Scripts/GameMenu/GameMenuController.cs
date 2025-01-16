using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace AirborneBall.GameMenu
{
    public class GameMenuController : MonoBehaviour
    {
        [SerializeField] private Button _buttonMenu;
        [SerializeField] private int _indexMainMenu;

        private void Awake()
        {
            _buttonMenu.onClick.AddListener(GoMenu);
        }

        private void OnDestroy()
        {
            _buttonMenu.onClick.RemoveListener(GoMenu);
        }

        private void GoMenu()
        {
            SceneManager.LoadScene(_indexMainMenu);
        }
    }
}
