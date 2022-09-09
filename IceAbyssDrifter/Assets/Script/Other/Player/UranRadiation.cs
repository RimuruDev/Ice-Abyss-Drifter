using RimuruDev.Mechanics.Character;
using System.Collections;
using UnityEngine;
using RimuruDev;

public sealed class UranRadiation : MonoBehaviour
{
    private GameDataContainer dataContainer;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Uran"))
        {
            if (dataContainer.Uran >= 1f)
            {
                StartCoroutine(nameof(MinusRadiation));
                if (dataContainer.UranRadiation <= 0f)
                {
                    Destroy(gameObject);

                    DeadPlayer.isDead = true;
                }
            }
        }
    }

    private void Update()
    {
        if (dataContainer.Uran >= 1f)
        {
            if (dataContainer.UranRadiation <= 0f)
            {
                Destroy(gameObject);
                DeadPlayer.isDead = true;
            }
        }
    }

    private IEnumerator MinusRadiation()
    {
        yield return new WaitForSeconds(0.7f);
        if (dataContainer.Uran <= 0f)
        {
            StopCoroutine(nameof(MinusRadiation));
            StartCoroutine(nameof(PlusRadiation));
        }
        else if (dataContainer.Uran >= 1f)
        {
            dataContainer.UranRadiation -= 1f;
            StartCoroutine(nameof(MinusRadiation));
            StopCoroutine(nameof(PlusRadiation));
        }

        if (DeadPlayer.isDead == true)
        {
            StopCoroutine(nameof(MinusRadiation));
        }
    }

    private IEnumerator PlusRadiation()
    {
        yield return new WaitForSeconds(0.5f);
        dataContainer.UranRadiation += 1f;
        if (dataContainer.UranRadiation < dataContainer.UranNormalRadiation)
        {
            StartCoroutine(nameof(PlusRadiation));
        }
        else if (dataContainer.UranRadiation == dataContainer.UranNormalRadiation)
        {
            StopCoroutine(nameof(PlusRadiation));
        }

        if (DeadPlayer.isDead == true)
        {
            StopCoroutine(nameof(PlusRadiation));
        }
    }
}