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
        dataContainer._inventor = dataContainer._pointUgly + dataContainer._porohPoint + dataContainer._uran + dataContainer._uranClear + dataContainer._horny + dataContainer._metal + dataContainer._rubin + dataContainer._clearRubin + dataContainer._cosmo;
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        //Ugly
        if (_coll.gameObject.CompareTag("Ugly"))
        {
            if (dataContainer._inventor < dataContainer._limitInventore)
            {
                dataContainer._pointUgly += 1f;
                Sfx();
            }
            else if (dataContainer._inventor >= dataContainer._limitInventore)
            {
                dataContainer._pointUgly += 0f;
                Sfx();
            }
        }
        //Metal
        if (_coll.gameObject.CompareTag("Metal"))
        {
            if (dataContainer._inventor < dataContainer._limitInventore)
            {
                dataContainer._metal += 1f;
                Sfx();
            }
            else if (dataContainer._inventor >= dataContainer._limitInventore)
            {
                dataContainer._metal += 0f;
                Sfx();
            }
        }
        //Gold
        if (_coll.gameObject.CompareTag("Gold"))
        {
            dataContainer._pointMoney += 20f;
            _goldSpound.Play();
        }
        //Uran
        if (_coll.gameObject.CompareTag("Uran"))
        {
            if (dataContainer._inventor < dataContainer._limitInventore)
            {
                dataContainer._uran += 1f;
                Sfx();
            }
            else if (dataContainer._inventor >= dataContainer._limitInventore)
            {
                if (MagazineWorkest._radiationSold == true)
                {
                    dataContainer._uran += 0f;
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
            if (dataContainer._inventor < dataContainer._limitInventore)
            {
                dataContainer._horny += 1f;
                _horneSpound.Play();
            }
            else if (dataContainer._inventor >= dataContainer._limitInventore)
            {
                dataContainer._horny += 0f;
                _horneSpound.Play();
            }
        }
        //Rubin
        if (_coll.gameObject.CompareTag("Rubin"))
        {
            if (dataContainer._inventor < dataContainer._limitInventore)
            {
                dataContainer._rubin += 1f;
                Sfx();
            }
            else if (dataContainer._inventor >= dataContainer._limitInventore)
            {
                dataContainer._rubin += 0f;
                Sfx();
            }
        }
        //Cosmo
        if (_coll.gameObject.CompareTag("Cosmo"))
        {
            if (dataContainer._inventor < dataContainer._limitInventore)
            {
                dataContainer._cosmo += 1f;
                Sfx();
            }
            else if (dataContainer._inventor >= dataContainer._limitInventore)
            {
                dataContainer._cosmo += 0f;
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
            if (dataContainer._pointUgly >= 1f || dataContainer._uran >= 1f || dataContainer._metal >= 1f || dataContainer._rubin >= 1f)
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
        if (dataContainer._pointUgly >= 1f)
        {
            dataContainer._porohPoint += 1f;
            dataContainer._pointUgly -= 1f;
            if (dataContainer._pointUgly >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Uran
        if (dataContainer._uran >= 1f)
        {
            dataContainer._uranClear += 1f;
            dataContainer._uran -= 1f;
            if (dataContainer._uran >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Metal
        if (dataContainer._metal >= 1f)
        {
            dataContainer._metalBullet += 1f;
            dataContainer._metal -= 1f;
            if (dataContainer._metal >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Rubin
        if (dataContainer._rubin >= 1f)
        {
            dataContainer._clearRubin += 1f;
            dataContainer._rubin -= 1f;
            if (dataContainer._rubin >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }

        if (dataContainer._pointUgly <= 0f && dataContainer._uran <= 0f && dataContainer._metal <= 0f && dataContainer._rubin <= 0f)
        {
            StopCoroutine(nameof(Raporting));
            _raportMachine.Play();
        }
    }

    private IEnumerator Solding()
    {
        yield return new WaitForSeconds(0.1f);
        //Sold Ugly
        if (dataContainer._porohPoint >= 1f)
        {
            dataContainer._porohPoint -= 1f;
            dataContainer._pointMoney += 5f;
            if (dataContainer._porohPoint >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        else if (dataContainer._pointUgly >= 1f)
        {
            dataContainer._pointUgly -= 1f;
            dataContainer._pointMoney += 3f;
            if (dataContainer._pointUgly >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Uran
        if (dataContainer._uranClear >= 1f)
        {
            dataContainer._uranClear -= 1f;
            dataContainer._pointMoney += 20f;
            if (dataContainer._uranClear >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        else if (dataContainer._uran >= 1f)
        {
            dataContainer._uran -= 1f;
            dataContainer._pointMoney += 13f;
            if (dataContainer._uran >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Horny
        if (dataContainer._horny >= 1f)
        {
            dataContainer._horny -= 1f;
            dataContainer._pointMoney += 9f;
            if (dataContainer._horny >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Metal
        if (dataContainer._metal >= 1f)
        {
            dataContainer._metal -= 1f;
            dataContainer._pointMoney += 6f;
            if (dataContainer._metal >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Rubin
        if (dataContainer._rubin >= 1f)
        {
            dataContainer._rubin -= 1f;
            dataContainer._pointMoney += 13f;
            if (dataContainer._rubin >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //ClearRubin
        if (dataContainer._clearRubin >= 1f)
        {
            dataContainer._clearRubin -= 1f;
            dataContainer._pointMoney += 18f;
            if (dataContainer._clearRubin >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Cosmo
        if (dataContainer._cosmo >= 1f)
        {
            dataContainer._cosmo -= 1f;
            dataContainer._pointMoney += 20f;
            if (dataContainer._cosmo >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }

        if (dataContainer._porohPoint <= 0f && dataContainer._pointUgly <= 0f && dataContainer._uran <= 0f && dataContainer._uranClear <= 0f && dataContainer._horny <= 0f && dataContainer._metal <= 0f && dataContainer._clearRubin <= 0f && dataContainer._rubin <= 0f && dataContainer._cosmo <= 0f)
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