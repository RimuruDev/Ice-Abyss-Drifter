using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prekol : MonoBehaviour
{
    [SerializeField] AudioClip _pigstep;
    [SerializeField] AudioClip _gameThemeclip;
    [SerializeField] AudioClip _wait;
    [SerializeField] AudioClip _DOOM;
    [SerializeField] AudioClip _Sus;
 
    [SerializeField] AudioSource _gameTheme;

    void Update()
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
        if (Input.GetKeyDown(KeyCode.F4))
        {
            _gameTheme.clip = _DOOM;
            _gameTheme.Play();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            _gameTheme.clip = _Sus;
            _gameTheme.Play();
        }
    }
}
