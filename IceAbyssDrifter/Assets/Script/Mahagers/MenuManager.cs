using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    [SerializeField] AudioSource _gameTheme;
    [SerializeField] AudioSource _wind;
    [SerializeField] AudioSource _pauseTheme;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PauseStop()
    {
        _panel.SetActive(false);
        GameManager._isPaused = false;
        _gameTheme.volume = 0.671f;
        _wind.volume = 0.274f;
        _pauseTheme.volume = 0;
        Time.timeScale = 1;
    }

    public void TimeNormal()
    {
        Time.timeScale = 1;
    }

    public void MuneReturn()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenURL2(string url2)
    {
        Application.OpenURL(url2);
    }
}
