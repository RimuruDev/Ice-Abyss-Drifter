using RimuruDev.Mechanics.Character;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject  panelPause;

    [SerializeField] private GameObject  deadPanel;

    [SerializeField] private AudioSource  gameTheme;
    [SerializeField] private AudioSource  wind;
    [SerializeField] private AudioSource  pauseTheme;

    public static bool  isPaused = false;

    public static float  pointMoney = 20f;

    public static float  pointUgly = 0f;
    public static float  porohPoint = 0f;

    public static float  inventor = 0f;
    public static float  limitInventore = 10f;

    public static float  uran = 0f;
    public static float  uranClear = 0f;
    public static float  uranRadiation = 0f;
    public static float  uranNormalRadiation;

    public static float  horny = 0f;

    public static float  metal = 0f;
    public static float  metalBullet = 0f;

    public static float  rubin = 0f;
    public static float  clearRubin = 0f;

    public static float  cosmo = 0f;

    [SerializeField] private GameObject  limitTexti;

    [Header("MoneyText")]
    [SerializeField] private Text  moneyText;
    [SerializeField] private Text  twoMoneyText;
    [SerializeField] private Text  treeMoneyText;

    [Header("Inventore")]
    [SerializeField] private Text  inventoreText;
    [SerializeField] private Text  inventoreGameText;
    [SerializeField] private Text  limitText;
    [SerializeField] private Text  limitGameText;

    [Header("Uglys")]
    [SerializeField] private Text  uglyText;
    [SerializeField] private Text  porohText;

    [Header("Uranys")]
    [SerializeField] private Text  uranText;
    [SerializeField] private Text  claerUranText;
    [SerializeField] private Text  radiathionText;

    [Header("Hornys")]
    [SerializeField] private Text  hornyText;

    [Header("Metal")]
    [SerializeField] private Text  metalText;
    [SerializeField] private Text  inInventBullet;
    [SerializeField] private Text  bulletText;

    [Header("Rubin")]
    [SerializeField] private Text  rubinText;
    [SerializeField] private Text  clearRubinText;

    [Header("Cosmo")]
    [SerializeField] private Text  cosmoText;

    private void Start()
    {
        Time.timeScale = 1;

         uranNormalRadiation =  uranRadiation;

         isPaused = false;

         pointMoney = 200;

        CharacterController. speed = 7f;

         horny = 0f;
         metal = 0f;
         metalBullet = 0f;
         inventor = 0f;
         limitInventore = 10f;
         uran = 0f;
         uranClear = 0f;
         pointUgly = 0f;
         porohPoint = 0f;
         uranNormalRadiation = 0f;
         uranRadiation = 0f;
         clearRubin = 0f;
         rubin = 0f;
         cosmo = 0f;

        MagazineWorkest. gunSold = false;
        MagazineWorkest. inventoreBigSold = false;
        MagazineWorkest. inventoreNormalSold = false;
        MagazineWorkest. petSold = false;
        MagazineWorkest. radiationSold = false;
        MagazineWorkest. speedSold = false;
        MagazineWorkest. idSold = false;
        MagazineWorkest. treckerSold = false;

        PostScript. idIsYou = false;

        LutingPlayer. heKeng = false;
    }

    private void Update()
    {
         moneyText.text =  pointMoney.ToString();
         twoMoneyText.text =  pointMoney.ToString();
         treeMoneyText.text =  pointMoney.ToString();

        if ( inventor ==  limitInventore)
        {
             inventor =  limitInventore;
        }

        if (DeadPlayer. isDead == true)
        {
             deadPanel.SetActive(true);
             gameTheme.Stop();
        }

        if ( pointMoney >= 1225)
        {
            SceneManager.LoadScene(2);
        }

        if ( inventor >=  limitInventore)
        {
             limitTexti.SetActive(true);
        }
        else if ( inventor <  limitInventore)
        {
             limitTexti.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape) && LutingPlayer. isMagazineOpen == false && DeadPlayer. isDead == false && ManagerInvent. inventorOpen == false)
        {
             panelPause.SetActive(true);
             isPaused = true;
             gameTheme.volume = 0;
             wind.volume = 0;
             pauseTheme.volume = 0.671f;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate()
    {
         inventoreText.text =  inventor.ToString();
         inventoreGameText.text =  inventor.ToString();
         limitText.text =  limitInventore.ToString();
         limitGameText.text =  limitInventore.ToString();

         uglyText.text =  pointUgly.ToString();
         porohText.text =  porohPoint.ToString();

         uranText.text =  uran.ToString();
         claerUranText.text =  uranClear.ToString();
         radiathionText.text =  uranRadiation.ToString();

         hornyText.text =  horny.ToString();

         metalText.text =  metal.ToString();
         bulletText.text =  metalBullet.ToString();
         inInventBullet.text =  metalBullet.ToString();

         rubinText.text =  rubin.ToString();
         clearRubinText.text =  clearRubin.ToString();

         cosmoText.text =  cosmo.ToString();
    }
}