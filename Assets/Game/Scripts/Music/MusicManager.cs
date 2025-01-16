using UnityEngine;

namespace AirborneBall.Music
{
    public class MusicManager : MonoBehaviour
    {
        public static bool IsPlayMusic => _isPlayMusic;

        [SerializeField] private AudioSource _audioSource;

        private static MusicManager _instance;
        private static bool _isPlayMusic = true;

        public static MusicManager Instance => _instance;

        public void ActivateMusic()
        {
            _isPlayMusic = true;
            _audioSource.Play();
        }

        public void DeactivateMusic()
        {
            _isPlayMusic = false;
            _audioSource.Stop();
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
                _audioSource.Play();
                _isPlayMusic = true;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
