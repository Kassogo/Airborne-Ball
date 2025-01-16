using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AirborneBall.Settings
{
    using Music;
    public class SettingsController : MonoBehaviour
    {
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _musicButton;
        [SerializeField] private GameObject _panelSettingsMenu;
        [Space]
        [SerializeField] private Image _musicPicture;
        [SerializeField] private Sprite _musicOn;
        [SerializeField] private Sprite _musicOff;

        private void Start()
        {
            _musicPicture.sprite = MusicManager.IsPlayMusic ? _musicOn : _musicOff;
            _settingButton.onClick.AddListener(TapSetting);
            _musicButton.onClick.AddListener(ChangeMusicStatus);
        }

        private void OnDestroy()
        {
            _settingButton.onClick.RemoveListener(TapSetting);
            _musicButton.onClick.RemoveListener(ChangeMusicStatus);
        }

        private void TapSetting()
        {
            _panelSettingsMenu.SetActive(!_panelSettingsMenu.activeSelf);
        }

        private void ChangeMusicStatus()
        {
            if (MusicManager.IsPlayMusic)
                MusicManager.Instance.DeactivateMusic();
            else
                MusicManager.Instance.ActivateMusic();
            _musicPicture.sprite = MusicManager.IsPlayMusic ? _musicOn : _musicOff;
        }
    }
}
