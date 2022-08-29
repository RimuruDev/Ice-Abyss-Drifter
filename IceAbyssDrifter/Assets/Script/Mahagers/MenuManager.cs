using UnityEngine;
using UnityEngine.SceneManagement;

namespace RimuruDev.UI
{
    public sealed class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [Space]
        [SerializeField] private AudioSource _gameTheme;
        [SerializeField] private AudioSource _wind;
        [SerializeField] private AudioSource _pauseTheme;

        private void Start() => TimeNormal();

        public void LoadMenuScene() => SceneManager.LoadScene(0);
        public void LoadGameScene() => SceneManager.LoadScene(1);

        public void TimeNormal() => Time.timeScale = 1;
        public void TimeStopped() => Time.timeScale = 0;

        public void Exit() => Application.Quit();

        public void PauseStop()
        {
            _panel.SetActive(false);

            GameManager._isPaused = false;

            _gameTheme.volume = 0.671f;
            _wind.volume = 0.274f;
            _pauseTheme.volume = 0;

            TimeNormal();
        }

        public void OpenURL(string url) => Application.OpenURL(url);
    }
}