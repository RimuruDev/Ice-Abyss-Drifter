using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UranRadiation : MonoBehaviour
{
    [SerializeField] GameObject _heartImage;
    [SerializeField] GameObject _effectLive;
    [SerializeField] AudioSource _teleportLife;

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Uran") && MagazineWorkest._radiationSold == true)
        {
            if (GameManager._uran >= 1f)
            {
                StartCoroutine("MinusRadiation");
                if (GameManager._uranRadiation <= 0f && SouthPickUp._isLive == false)
                {   
                    Destroy(gameObject);
                    DeadPlayer._isDead = true;  
                }
                else if (GameManager._uranRadiation <= 0f && SouthPickUp._isLive == true)
                {
                    transform.position = new Vector2(Random.Range(-110, 110), Random.Range(70, -25));
                    GameManager._uran = 0f;
                    _teleportLife.Play();
                    Instantiate(_effectLive, gameObject.transform.position, Quaternion.identity);
                    GameManager._uranRadiation = GameManager._uranNormalRadiation;
                    SouthPickUp._isLive = false;
                    _heartImage.SetActive(false);
                }
            }
        }
        else if (_coll.gameObject.CompareTag("Uran") && SouthPickUp._isLive == true && MagazineWorkest._radiationSold == false)
        {
            GameManager._uran = 0f;
            transform.position = new Vector2(Random.Range(-110, 110), Random.Range(70, -25));
            _teleportLife.Play();
            Instantiate(_effectLive, gameObject.transform.position, Quaternion.identity);
            SouthPickUp._isLive = false;
            _heartImage.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager._uran >= 1f)
        {
            if (GameManager._uranRadiation <= 0f && SouthPickUp._isLive == false)
            {
                Destroy(gameObject);
                DeadPlayer._isDead = true;
            }
            else if (GameManager._uranRadiation <= 0f && SouthPickUp._isLive == true)
            {
                transform.position = new Vector2(Random.Range(-110, 110), Random.Range(70, -25));
                Instantiate(_effectLive, gameObject.transform.position, Quaternion.identity);
                _teleportLife.Play();
                GameManager._uranRadiation = GameManager._uranNormalRadiation;
                SouthPickUp._isLive = false;
                GameManager._uran = 0f;
                _heartImage.SetActive(false);
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
