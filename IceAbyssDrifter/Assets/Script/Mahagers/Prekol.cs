using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Prekol : MonoBehaviour
{
    [SerializeField] private AudioClip _pigstep;
    [SerializeField] private AudioClip _gameThemeclip;
    [SerializeField] private AudioClip _wait;

    [SerializeField] private AudioSource _gameTheme;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            _gameTheme.clip = _pigstep;
            _gameTheme.Play();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            _gameTheme.clip = _gameThemeclip;
            _gameTheme.Play();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            _gameTheme.clip = _wait;
            _gameTheme.Play();
        }
    }
}
