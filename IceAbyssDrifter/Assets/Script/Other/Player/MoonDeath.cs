using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonDeath : MonoBehaviour
{
    [SerializeField] GameObject _obj;
    [SerializeField] Text _timerText;

    [SerializeField] GameObject _heartImage;
    [SerializeField] GameObject _effectLive;
    [SerializeField] AudioSource _teleportLife;

    private float _timer;
    private float _normalTime;

    void Start()
    {
        _timer = 200f;
        _normalTime = _timer;
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Moon"))
        {
            _obj.SetActive(true);
            StartCoroutine("deathTimer");
        }
    }

    void FixedUpdate()
    {
        _timerText.text = _timer.ToString();

        if (GameManager._moonDirt <= 0f)
        {
            _obj.SetActive(false);
        }

        if (_timer <= 0f && SouthPickUp._isLive == false)
        {
            Destroy(gameObject);
            StopCoroutine("deathTimer");
            _obj.SetActive(false);
            DeadPlayer._isDead = true;
        }
        else if (_timer <= 0f && SouthPickUp._isLive == true)
        {
            transform.position = new Vector2(Random.Range(-110, 110), Random.Range(70, -25));
            Instantiate(_effectLive, gameObject.transform.position, Quaternion.identity);
            SouthPickUp._isLive = false;
            _teleportLife.Play();
            _timer = _normalTime;
            _heartImage.SetActive(false);
            GameManager._moonDirt = 0f;
        }
    }

    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(1f);
        if (GameManager._moonDirt >= 1f)
        {
            _timer -= 1f;
            if (GameManager._moonDirt >= 1f)
            {
                StartCoroutine("deathTimer");
            }
        }
        else if (GameManager._moonDirt <= 0f)
        {
            StopCoroutine("deathTimer");
            _timer = _normalTime;
            _obj.SetActive(false);
        }
    }

}
