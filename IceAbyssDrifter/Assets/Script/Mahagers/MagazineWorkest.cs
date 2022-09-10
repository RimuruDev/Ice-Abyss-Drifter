using RimuruDev;
using UnityEngine;

public sealed class MagazineWorkest : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private GameObject  petHappy;
    [SerializeField] private GameObject  petNormal;
    [SerializeField] private GameObject  petSad;

    [SerializeField] private GameObject  trecker;

    [Header("DereactPost")]
    [SerializeField] private GameObject  panelSpeed;
    [SerializeField] private GameObject  panelRadiation;
    [SerializeField] private GameObject  panelNormal;
    [SerializeField] private GameObject  panelBig;
    [SerializeField] private GameObject  panelGun;
    [SerializeField] private GameObject  panelID;
    [SerializeField] private GameObject  panelPet;

    [Header("Posters")]
    [SerializeField] private GameObject  postSpeed;
    [SerializeField] private GameObject  postRadiation;
    [SerializeField] private GameObject  postNormalInvenore;
    [SerializeField] private GameObject  postBigInventore;
    [SerializeField] private GameObject  postGun;
    [SerializeField] private GameObject  postPet;
    [SerializeField] private GameObject  postID;

    [SerializeField] private AudioSource  buySound;

    public static bool  speedSold = false;
    public static bool  radiationSold = false;
    public static bool  inventoreNormalSold = false;
    public static bool  inventoreBigSold = false;
    public static bool  petSold = false;
    public static bool  gunSold = false;
    public static bool  idSold = false;
    public static bool  treckerSold = false;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    public void BuyRadiation()
    {
        if (dataContainer.PointMoney >= 275f)
        {
            dataContainer.PointMoney -= 275f; ;

             postRadiation.SetActive(true);
             panelRadiation.SetActive(true);
             buySound.Play();
             radiationSold = true;
        }
    }

    public void BuySpeed()
    {
        if (dataContainer.PointMoney >= 150f)
        {
            dataContainer.PointMoney -= 150f;

             postSpeed.SetActive(true);
             panelSpeed.SetActive(true);
             buySound.Play();
             speedSold = true;
        }
    }

    public void BuyNormalInventore()
    {
        if (dataContainer.PointMoney >= 180f)
        {
            dataContainer.PointMoney -= 180f;

             postNormalInvenore.SetActive(true);
             panelNormal.SetActive(true);
             buySound.Play();
             inventoreNormalSold = true;
        }
    }

    public void BuyBigInventore()
    {
        if (dataContainer.PointMoney >= 300f)
        {
            dataContainer.PointMoney -= 300f;

             postBigInventore.SetActive(true);
             panelBig.SetActive(true);
             buySound.Play();
             inventoreBigSold = true;
        }
    }

    public void BuyPet()
    {
        if (dataContainer.PointMoney >= 50f)
        {
            dataContainer.PointMoney -= 50f;

             postPet.SetActive(true);
             panelPet.SetActive(true);
             buySound.Play();
             petSold = true;
        }
    }

    public void BuyGun()
    {
        if (dataContainer.PointMoney >= 250f)
        {
            dataContainer.PointMoney -= 250f;

             postGun.SetActive(true);
             panelGun.SetActive(true);
             buySound.Play();
             gunSold = true;
        }
    }

    public void BuyID()
    {
        if (dataContainer.PointMoney >= 200f)
        {
            dataContainer.PointMoney -= 200f;

             postID.SetActive(true);
             panelID.SetActive(true);
             buySound.Play();
             idSold = true;
        }
    }

    public void BuyTreker()
    {
        if (dataContainer.PointMoney >= 100f)
        {
            dataContainer.PointMoney -= 100f;

             trecker.SetActive(true);
             buySound.Play();
             treckerSold = true;
        }
    }

    public void ExitMagazine()
    {
        LutingPlayer. isMagazineOpen = false;

        Time.timeScale = 1;
    }
}