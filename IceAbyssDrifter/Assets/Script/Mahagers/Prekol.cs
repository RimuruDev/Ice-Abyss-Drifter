using UnityEngine;

public sealed class Prekol : MonoBehaviour
{
    [SerializeField] private AudioClip pigstep;
    [SerializeField] private AudioClip gameThemeclip;
    [SerializeField] private AudioClip wait;

    [SerializeField] private AudioSource gameTheme;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gameTheme.clip = pigstep;
            gameTheme.Play();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            gameTheme.clip = gameThemeclip;
            gameTheme.Play();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            gameTheme.clip = wait;
            gameTheme.Play();
        }
    }
}
