using RimuruDev;
using UnityEngine;

public sealed class MagazineWorkest : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private GameObject _petHappy;
    [SerializeField] private GameObject _petNormal;
    [SerializeField] private GameObject _petSad;

    [SerializeField] private GameObject _trecker;

    [Header("DereactPost")]
    [SerializeField] private GameObject _panelSpeed;
    [SerializeField] private GameObject _panelRadiation;
    [SerializeField] private GameObject _panelNormal;
    [SerializeField] private GameObject _panelBig;
    [SerializeField] private GameObject _panelGun;
    [SerializeField] private GameObject _panelID;
    [SerializeField] private GameObject _panelPet;

    [Header("Posters")]
    [SerializeField] private GameObject _postSpeed;
    [SerializeField] private GameObject _postRadiation;
    [SerializeField] private GameObject _postNormalInvenore;
    [SerializeField] private GameObject _postBigInventore;
    [SerializeField] private GameObject _postGun;
    [SerializeField] private GameObject _postPet;
    [SerializeField] private GameObject _postID;

    [SerializeField] private AudioSource _buySound;

    public static bool _speedSold = false;
    public static bool _radiationSold = false;
    public static bool _inventoreNormalSold = false;
    public static bool _inventoreBigSold = false;
    public static bool _petSold = false;
    public static bool _gunSold = false;
    public static bool _idSold = false;
    public static bool _treckerSold = false;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    public void BuyRadiation()
    {
        if (dataContainer.PointMoney >= 275f)
        {
            dataContainer.PointMoney -= 275f; ;

            _postRadiation.SetActive(true);
            _panelRadiation.SetActive(true);
            _buySound.Play();
            _radiationSold = true;
        }
    }

    public void BuySpeed()
    {
        if (dataContainer.PointMoney >= 150f)
        {
            dataContainer.PointMoney -= 150f;

            _postSpeed.SetActive(true);
            _panelSpeed.SetActive(true);
            _buySound.Play();
            _speedSold = true;
        }
    }

    public void BuyNormalInventore()
    {
        if (dataContainer.PointMoney >= 180f)
        {
            dataContainer.PointMoney -= 180f;

            _postNormalInvenore.SetActive(true);
            _panelNormal.SetActive(true);
            _buySound.Play();
            _inventoreNormalSold = true;
        }
    }

    public void BuyBigInventore()
    {
        if (dataContainer.PointMoney >= 300f)
        {
            dataContainer.PointMoney -= 300f;

            _postBigInventore.SetActive(true);
            _panelBig.SetActive(true);
            _buySound.Play();
            _inventoreBigSold = true;
        }
    }

    public void BuyPet()
    {
        if (dataContainer.PointMoney >= 50f)
        {
            dataContainer.PointMoney -= 50f;

            _postPet.SetActive(true);
            _panelPet.SetActive(true);
            _buySound.Play();
            _petSold = true;
        }
    }

    public void BuyGun()
    {
        if (dataContainer.PointMoney >= 250f)
        {
            dataContainer.PointMoney -= 250f;

            _postGun.SetActive(true);
            _panelGun.SetActive(true);
            _buySound.Play();
            _gunSold = true;
        }
    }

    public void BuyID()
    {
        if (dataContainer.PointMoney >= 200f)
        {
            dataContainer.PointMoney -= 200f;

            _postID.SetActive(true);
            _panelID.SetActive(true);
            _buySound.Play();
            _idSold = true;
        }
    }

    public void BuyTreker()
    {
        if (dataContainer.PointMoney >= 100f)
        {
            dataContainer.PointMoney -= 100f;

            _trecker.SetActive(true);
            _buySound.Play();
            _treckerSold = true;
        }
    }

    public void ExitMagazine()
    {
        LutingPlayer._isMagazineOpen = false;

        Time.timeScale = 1;
    }
}