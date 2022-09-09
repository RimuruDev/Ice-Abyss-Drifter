using UnityEngine;
using UnityEngine.SceneManagement;

namespace RimuruDev.UI
{
    public sealed class MenuManager : MonoBehaviour
    {
        private GameDataContainer dataContainer;

        [SerializeField] private GameObject panel;
        [Space]
        [SerializeField] private AudioSource gameTheme;
        [SerializeField] private AudioSource wind;
        [SerializeField] private AudioSource pauseTheme;

        private void Awake()
        {
            dataContainer = FindObjectOfType<GameDataContainer>();
        }

        private void Start() => TimeNormal();

        public void LoadMenuScene() => SceneManager.LoadScene(0);
        public void LoadGameScene() => SceneManager.LoadScene(1);

        public void TimeNormal() => Time.timeScale = 1;
        public void TimeStopped() => Time.timeScale = 0;

        public void ExitTheGame() => Application.Quit();

        public void PauseStop()
        {
            panel.SetActive(false);

            dataContainer.IsPaused = false;

            gameTheme.volume = 0.671f;
            wind.volume = 0.274f;
            pauseTheme.volume = 0;

            TimeNormal();
        }

        public void OpenURL(string url) => Application.OpenURL(url);
    }
}