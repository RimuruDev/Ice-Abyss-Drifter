using RimuruDev;
using RimuruDev.Mechanics.Character;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public sealed class LutingPlayer : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private GameObject panelMagazine;
    [SerializeField] private GameObject keng;

    public static bool heKeng = false;

    [Header("Audio")]
    [SerializeField] private AudioSource boomAudio;
    [SerializeField] private AudioSource horneSpound;
    [SerializeField] private AudioSource goldSpound;
    [SerializeField] private AudioSource raportMachine;
    [SerializeField] private AudioSource soldMachine;

    public static bool isMagazineOpen = false;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    private void FixedUpdate()
    {
        dataContainer.Inventor = dataContainer.PointUgly + dataContainer.PorohPoint + dataContainer.Uran + dataContainer.UranClear + dataContainer.Horny + dataContainer.Metal + dataContainer.Rubin + dataContainer.ClearRubin + dataContainer.Cosmo;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Ugly
        if (coll.gameObject.CompareTag("Ugly"))
        {
            if (dataContainer.Inventor < dataContainer.LimitInventore)
            {
                dataContainer.PointUgly += 1f;
                Sfx();
            }
            else if (dataContainer.Inventor >= dataContainer.LimitInventore)
            {
                dataContainer.PointUgly += 0f;
                Sfx();
            }
        }
        //Metal
        if (coll.gameObject.CompareTag("Metal"))
        {
            if (dataContainer.Inventor < dataContainer.LimitInventore)
            {
                dataContainer.Metal += 1f;
                Sfx();
            }
            else if (dataContainer.Inventor >= dataContainer.LimitInventore)
            {
                dataContainer.Metal += 0f;
                Sfx();
            }
        }
        //Gold
        if (coll.gameObject.CompareTag("Gold"))
        {
            dataContainer.PointMoney += 20f;
            goldSpound.Play();
        }
        //Uran
        if (coll.gameObject.CompareTag("Uran"))
        {
            if (dataContainer.Inventor < dataContainer.LimitInventore)
            {
                dataContainer.Uran += 1f;
                Sfx();
            }
            else if (dataContainer.Inventor >= dataContainer.LimitInventore)
            {
                if (MagazineWorkest.radiationSold == true)
                {
                    dataContainer.Uran += 0f;
                    Sfx();
                }
                else if (MagazineWorkest.radiationSold == false)
                {
                    Destroy(gameObject);
                    DeadPlayer.isDead = true;
                }
            }
        }
        //Horny
        if (coll.gameObject.CompareTag("Horny"))
        {
            if (dataContainer.Inventor < dataContainer.LimitInventore)
            {
                dataContainer.Horny += 1f;
                horneSpound.Play();
            }
            else if (dataContainer.Inventor >= dataContainer.LimitInventore)
            {
                dataContainer.Horny += 0f;
                horneSpound.Play();
            }
        }
        //Rubin
        if (coll.gameObject.CompareTag("Rubin"))
        {
            if (dataContainer.Inventor < dataContainer.LimitInventore)
            {
                dataContainer.Rubin += 1f;
                Sfx();
            }
            else if (dataContainer.Inventor >= dataContainer.LimitInventore)
            {
                dataContainer.Rubin += 0f;
                Sfx();
            }
        }
        //Cosmo
        if (coll.gameObject.CompareTag("Cosmo"))
        {
            if (dataContainer.Inventor < dataContainer.LimitInventore)
            {
                dataContainer.Cosmo += 1f;
                Sfx();
            }
            else if (dataContainer.Inventor >= dataContainer.LimitInventore)
            {
                dataContainer.Cosmo += 0f;
                Sfx();
            }
        }

        if (coll.gameObject.CompareTag("Magas"))
        {
            panelMagazine.SetActive(true);
            isMagazineOpen = true;
            Time.timeScale = 0;
        }

        if (coll.gameObject.CompareTag("Raport"))
        {
            if (dataContainer.PointUgly >= 1f || dataContainer.Uran >= 1f || dataContainer.Metal >= 1f || dataContainer.Rubin >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }

        if (coll.gameObject.CompareTag("Sold"))
        {
            StartCoroutine(nameof(Solding));
        }

        if (coll.gameObject.CompareTag("King"))
        {
            heKeng = true;
            keng.SetActive(true);
        }
    }

    private IEnumerator Raporting()
    {
        yield return new WaitForSeconds(0.1f);

        //Uglys
        if (dataContainer.PointUgly >= 1f)
        {
            dataContainer.PorohPoint += 1f;
            dataContainer.PointUgly -= 1f;
            if (dataContainer.PointUgly >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Uran
        if (dataContainer.Uran >= 1f)
        {
            dataContainer.UranClear += 1f;
            dataContainer.Uran -= 1f;
            if (dataContainer.Uran >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Metal
        if (dataContainer.Metal >= 1f)
        {
            dataContainer.MetalBullet += 1f;
            dataContainer.Metal -= 1f;
            if (dataContainer.Metal >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }
        //Rubin
        if (dataContainer.Rubin >= 1f)
        {
            dataContainer.ClearRubin += 1f;
            dataContainer.Rubin -= 1f;
            if (dataContainer.Rubin >= 1f)
            {
                StartCoroutine(nameof(Raporting));
            }
        }

        if (dataContainer.PointUgly <= 0f && dataContainer.Uran <= 0f && dataContainer.Metal <= 0f && dataContainer.Rubin <= 0f)
        {
            StopCoroutine(nameof(Raporting));
            raportMachine.Play();
        }
    }

    private IEnumerator Solding()
    {
        yield return new WaitForSeconds(0.1f);
        //Sold Ugly
        if (dataContainer.PorohPoint >= 1f)
        {
            dataContainer.PorohPoint -= 1f;
            dataContainer.PointMoney += 5f;
            if (dataContainer.PorohPoint >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        else if (dataContainer.PointUgly >= 1f)
        {
            dataContainer.PointUgly -= 1f;
            dataContainer.PointMoney += 3f;
            if (dataContainer.PointUgly >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Uran
        if (dataContainer.UranClear >= 1f)
        {
            dataContainer.UranClear -= 1f;
            dataContainer.PointMoney += 20f;
            if (dataContainer.UranClear >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        else if (dataContainer.Uran >= 1f)
        {
            dataContainer.Uran -= 1f;
            dataContainer.PointMoney += 13f;
            if (dataContainer.Uran >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Horny
        if (dataContainer.Horny >= 1f)
        {
            dataContainer.Horny -= 1f;
            dataContainer.PointMoney += 9f;
            if (dataContainer.Horny >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Sold Metal
        if (dataContainer.Metal >= 1f)
        {
            dataContainer.Metal -= 1f;
            dataContainer.PointMoney += 6f;
            if (dataContainer.Metal >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Rubin
        if (dataContainer.Rubin >= 1f)
        {
            dataContainer.Rubin -= 1f;
            dataContainer.PointMoney += 13f;
            if (dataContainer.Rubin >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //ClearRubin
        if (dataContainer.ClearRubin >= 1f)
        {
            dataContainer.ClearRubin -= 1f;
            dataContainer.PointMoney += 18f;
            if (dataContainer.ClearRubin >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }
        //Cosmo
        if (dataContainer.Cosmo >= 1f)
        {
            dataContainer.Cosmo -= 1f;
            dataContainer.PointMoney += 20f;
            if (dataContainer.Cosmo >= 1f)
            {
                StartCoroutine(nameof(Solding));
            }
        }

        if (dataContainer.PorohPoint <= 0f && dataContainer.PointUgly <= 0f && dataContainer.Uran <= 0f && dataContainer.UranClear <= 0f && dataContainer.Horny <= 0f && dataContainer.Metal <= 0f && dataContainer.ClearRubin <= 0f && dataContainer.Rubin <= 0f && dataContainer.Cosmo <= 0f)
        {
            StopCoroutine(nameof(Solding));
            soldMachine.Play();
        }
    }

    private void Sfx()
    {
        boomAudio.pitch = Random.Range(0.7f, 1f);
        boomAudio.Play();
    }
}