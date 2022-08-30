using RimuruDev.Mechanics.Character;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public sealed class LutingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _panelMagazine;
    [SerializeField] private GameObject _keng;

    public static bool _heKeng = false;

    [Header("Audio")]
    [SerializeField] private AudioSource _boomAudio;
    [SerializeField] private AudioSource _horneSpound;
    [SerializeField] private AudioSource _goldSpound;
    [SerializeField] private AudioSource _raportMachine;
    [SerializeField] private AudioSource _soldMachine;

    public static bool _isMagazineOpen = false;

    private void FixedUpdate()
    {
        GameManager._inventor = GameManager._pointUgly + GameManager._porohPoint + GameManager._uran + GameManager._uranClear + GameManager._horny + GameManager._metal + GameManager._rubin + GameManager._clearRubin + GameManager._cosmo;
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        //Ugly
        if (_coll.gameObject.CompareTag("Ugly"))
        {
            if (GameManager._inventor < GameManager._limitInventore)
            {
                GameManager._pointUgly += 1f;
                Sfx();
            }
            else if (GameManager._inventor >= GameManager._limitInventore)
            {
                GameManager._pointUgly += 0f;
                Sfx();
            }
        }
        //Metal
        if (_coll.gameObject.CompareTag("Metal"))
        {
            if (GameManager._inventor < GameManager._limitInventore)
            {
                GameManager._metal += 1f;
                Sfx();
            }
            else if (GameManager._inventor >= GameManager._limitInventore)
            {
                GameManager._metal += 0f;
                Sfx();
            }
        }
        //Gold
        if (_coll.gameObject.CompareTag("Gold"))
        {
            GameManager._pointMoney += 20f;
            _goldSpound.Play();
        }
        //Uran
        if (_coll.gameObject.CompareTag("Uran"))
        {
            if (GameManager._inventor < GameManager._limitInventore)
            {
                GameManager._uran += 1f;
                Sfx();
            }
            else if (GameManager._inventor >= GameManager._limitInventore)
            {
                if (MagazineWorkest._radiationSold == true)
                {
                    GameManager._uran += 0f;
                    Sfx();
                }
                else if (MagazineWorkest._radiationSold == false)
                {
                    Destroy(gameObject);
                    DeadPlayer._isDead = true;
                }
            }
        }
        //Horny
        if (_coll.gameObject.CompareTag("Horny"))
        {
            if (GameManager._inventor < GameManager._limitInventore)
            {
                GameManager._horny += 1f;
                _horneSpound.Play();
            }
            else if (GameManager._inventor >= GameManager._limitInventore)
            {
                GameManager._horny += 0f;
                _horneSpound.Play();
            }
        }
        //Rubin
        if (_coll.gameObject.CompareTag("Rubin"))
        {
            if (GameManager._inventor < GameManager._limitInventore)
            {
                GameManager._rubin += 1f;
                Sfx();
            }
            else if (GameManager._inventor >= GameManager._limitInventore)
            {
                GameManager._rubin += 0f;
                Sfx();
            }
        }
        //Cosmo
        if (_coll.gameObject.CompareTag("Cosmo"))
        {
            if (GameManager._inventor < GameManager._limitInventore)
            {
                GameManager._cosmo += 1f;
                Sfx();
            }
            else if (GameManager._inventor >= GameManager._limitInventore)
            {
                GameManager._cosmo += 0f;
                Sfx();
            }
        }

        if (_coll.gameObject.CompareTag("Magas"))
        {
            _panelMagazine.SetActive(true);
            _isMagazineOpen = true;
            Time.timeScale = 0;
        }

        if (_coll.gameObject.CompareTag("Raport"))
        {
            if (GameManager._pointUgly >= 1f || GameManager._uran >= 1f || GameManager._metal >= 1f || GameManager._rubin >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }

        if (_coll.gameObject.CompareTag("Sold"))
        {
            StartCoroutine(nameof(Solding));
        }

        if (_coll.gameObject.CompareTag("King"))
        {
            _heKeng = true;
            _keng.SetActive(true);
        }
    }

    private IEnumerator Raporting()
    {
        yield return new WaitForSeconds(0.1f);

        //Uglys
        if (GameManager._pointUgly >= 1f)
        {
            GameManager._porohPoint += 1f;
            GameManager._pointUgly -= 1f;
            if (GameManager._pointUgly >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Uran
        if (GameManager._uran >= 1f)
        {
            GameManager._uranClear += 1f;
            GameManager._uran -= 1f;
            if (GameManager._uran >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Metal
        if (GameManager._metal >= 1f)
        {
            GameManager._metalBullet += 1f;
            GameManager._metal -= 1f;
            if (GameManager._metal >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Rubin
        if (GameManager._rubin >= 1f)
        {
            GameManager._clearRubin += 1f;
            GameManager._rubin -= 1f;
            if (GameManager._rubin >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }

        if (GameManager._pointUgly <= 0f && GameManager._uran <= 0f && GameManager._metal <= 0f && GameManager._rubin <= 0f)
        {
            StopCoroutine(nameof(Raporting));
            _raportMachine.Play();
        }
    }

    private IEnumerator Solding()
    {
        yield return new WaitForSeconds(0.1f);
        //Sold Ugly
        if (GameManager._porohPoint >= 1f)
        {
            GameManager._porohPoint -= 1f;
            GameManager._pointMoney += 5f;
            if (GameManager._porohPoint >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        else if (GameManager._pointUgly >= 1f)
        {
            GameManager._pointUgly -= 1f;
            GameManager._pointMoney += 3f;
            if (GameManager._pointUgly >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Uran
        if (GameManager._uranClear >= 1f)
        {
            GameManager._uranClear -= 1f;
            GameManager._pointMoney += 20f;
            if (GameManager._uranClear >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        else if (GameManager._uran >= 1f)
        {
            GameManager._uran -= 1f;
            GameManager._pointMoney += 13f;
            if (GameManager._uran >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Horny
        if (GameManager._horny >= 1f)
        {
            GameManager._horny -= 1f;
            GameManager._pointMoney += 9f;
            if (GameManager._horny >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Metal
        if (GameManager._metal >= 1f)
        {
            GameManager._metal -= 1f;
            GameManager._pointMoney += 6f;
            if (GameManager._metal >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Rubin
        if (GameManager._rubin >= 1f)
        {
            GameManager._rubin -= 1f;
            GameManager._pointMoney += 13f;
            if (GameManager._rubin >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //ClearRubin
        if (GameManager._clearRubin >= 1f)
        {
            GameManager._clearRubin -= 1f;
            GameManager._pointMoney += 18f;
            if (GameManager._clearRubin >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Cosmo
        if (GameManager._cosmo >= 1f)
        {
            GameManager._cosmo -= 1f;
            GameManager._pointMoney += 20f;
            if (GameManager._cosmo >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }

        if (GameManager._porohPoint <= 0f && GameManager._pointUgly <= 0f && GameManager._uran <= 0f && GameManager._uranClear <= 0f && GameManager._horny <= 0f && GameManager._metal <= 0f && GameManager._clearRubin <= 0f && GameManager._rubin <= 0f && GameManager._cosmo <= 0f)
        {
            StopCoroutine(nameof(Solding));
            _soldMachine.Play();
        }
    }

    private void Sfx()
    {
        _boomAudio.pitch = Random.Range(0.7f, 1f);
        _boomAudio.Play();
    }
}