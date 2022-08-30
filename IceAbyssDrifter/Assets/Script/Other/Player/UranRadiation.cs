using RimuruDev.Mechanics.Character;
using System.Collections;
using UnityEngine;

public sealed class UranRadiation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Uran"))
        {
            if (GameManager._uran >= 1f)
            {
                StartCoroutine(nameof(MinusRadiation));
                if (GameManager._uranRadiation <= 0f)
                {
                    Destroy(gameObject);
                    DeadPlayer._isDead = true;
                }
            }
        }
    }

    private void Update()
    {
        if (GameManager._uran >= 1f)
        {
            if (GameManager._uranRadiation <= 0f)
            {
                Destroy(gameObject);
                DeadPlayer._isDead = true;
            }
        }
    }

    private IEnumerator MinusRadiation()
    {
        yield return new WaitForSeconds(0.7f);
        if (GameManager._uran <= 0f)
        {
            StopCoroutine(nameof(MinusRadiation));
            StartCoroutine(nameof(PlusRadiation));
        }
        else if (GameManager._uran >= 1f)
        {
            GameManager._uranRadiation -= 1f;
            StartCoroutine(nameof(MinusRadiation));
            StopCoroutine(nameof(PlusRadiation));
        }

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine(nameof(MinusRadiation));
        }
    }

    private IEnumerator PlusRadiation()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager._uranRadiation += 1f;
        if (GameManager._uranRadiation < GameManager._uranNormalRadiation)
        {
            StartCoroutine(nameof(PlusRadiation));
        }
        else if (GameManager._uranRadiation == GameManager._uranNormalRadiation)
        {
            StopCoroutine(nameof(PlusRadiation));
        }

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine(nameof(PlusRadiation));
        }
    }
}