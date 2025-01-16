using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AirborneBall.Tutorial
{
    public class TutorialController : MonoBehaviour
    {
        [SerializeField] private Button _tutorialButton;
        [SerializeField] private Button _showTutorialButton;
        [SerializeField] private List<TutorialNote> _notes;
        [SerializeField] private GameObject _tutorialPanel;
        [SerializeField] private TextMeshProUGUI _noteText;
        [SerializeField] private Image _notePicture;

        private bool _isShowTutorial = false;
        private int _indexNote;

        private void Awake()
        {
            _tutorialButton.onClick.AddListener(TapToTutorialButton);
            _showTutorialButton.onClick.AddListener(ShowNote);
        }

        private void OnDestroy()
        {
            _tutorialButton.onClick.RemoveListener(TapToTutorialButton);
            _showTutorialButton.onClick.RemoveListener(ShowNote);
        }

        private void TapToTutorialButton()
        {
            if (_isShowTutorial)
                CloseTutorial();
            else
                OpenTutorial();

            _isShowTutorial = !_isShowTutorial;
        }

        private void ShowNote()
        {
            _noteText.text = _notes[_indexNote].Note;
            _notePicture.sprite = _notes[_indexNote].Picture;

            _indexNote++;
            if (_indexNote == _notes.Count)
                _indexNote = 0;
        }

        private void OpenTutorial()
        {
            ShowNote();
            _tutorialPanel.SetActive(true);
        }

        private void CloseTutorial()
        {
            _indexNote = 0;
            _tutorialPanel.SetActive(false);
        }


        [Serializable]
        private class TutorialNote
        {
            public string Note;
            public Sprite Picture;
        }
    }
}
