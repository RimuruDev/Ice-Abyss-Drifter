using RimuruDev.Mechanics.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranRadiation : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Uran"))
        {
            if (GameManager._uran >= 1f)
            {
                StartCoroutine("MinusRadiation");
                if (GameManager._uranRadiation <= 0f)
                {
                    Destroy(gameObject);
                    DeadPlayer._isDead = true;
                }
            }
        }
    }

    void Update()
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

    IEnumerator MinusRadiation()
    {
        yield return new WaitForSeconds(0.7f);
        if (GameManager._uran <= 0f)
        {
            StopCoroutine("MinusRadiation");
            StartCoroutine("PlusRadiation");
        }
        else if (GameManager._uran >= 1f)
        {
            GameManager._uranRadiation -= 1f;
            StartCoroutine("MinusRadiation");
            StopCoroutine("PlusRadiation");
        } 

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine("MinusRadiation");
        }
    }

    IEnumerator PlusRadiation()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager._uranRadiation += 1f;
        if (GameManager._uranRadiation < GameManager._uranNormalRadiation)
        {
            StartCoroutine("PlusRadiation");
        }
        else if (GameManager._uranRadiation == GameManager._uranNormalRadiation)
        {
            StopCoroutine("PlusRadiation");
        }

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine("PlusRadiation");
        }
    }
}
