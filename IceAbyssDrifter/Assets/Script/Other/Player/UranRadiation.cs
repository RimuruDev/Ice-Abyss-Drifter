using RimuruDev.Mechanics.Character;
using System.Collections;
using UnityEngine;

public sealed class UranRadiation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Uran"))
        {
            if (dataContainer._uran >= 1f)
            {
                StartCoroutine(nameof(MinusRadiation));
                if (dataContainer._uranRadiation <= 0f)
                {
                    Destroy(gameObject);
                    DeadPlayer._isDead = true;
                }
            }
        }
    }

    private void Update()
    {
        if (dataContainer._uran >= 1f)
        {
            if (dataContainer._uranRadiation <= 0f)
            {
                Destroy(gameObject);
                DeadPlayer._isDead = true;
            }
        }
    }

    private IEnumerator MinusRadiation()
    {
        yield return new WaitForSeconds(0.7f);
        if (dataContainer._uran <= 0f)
        {
            StopCoroutine(nameof(MinusRadiation));
            StartCoroutine(nameof(PlusRadiation));
        }
        else if (dataContainer._uran >= 1f)
        {
            dataContainer._uranRadiation -= 1f;
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
        dataContainer._uranRadiation += 1f;
        if (dataContainer._uranRadiation < dataContainer._uranNormalRadiation)
        {
            StartCoroutine(nameof(PlusRadiation));
        }
        else if (dataContainer._uranRadiation == dataContainer._uranNormalRadiation)
        {
            StopCoroutine(nameof(PlusRadiation));
        }

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine(nameof(PlusRadiation));
        }
    }
}