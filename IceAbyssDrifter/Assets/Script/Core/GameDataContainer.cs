using RimuruDev.AI;
using RimuruDev.Mechanics.Character;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev
{
    public sealed class GameDataContainer : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject panelPause;
        [SerializeField] private GameObject deadPanel;
        [Space]
        [Header("Audio")]
        [SerializeField] private AudioSource gameTheme;
        [SerializeField] private AudioSource wind;
        [SerializeField] private AudioSource pauseTheme;
        [Space]
        [SerializeField] private bool isPaused = false;
        [Space]
        [SerializeField] private float pointMoney = 20f;
        [Space]
        [SerializeField] private float pointUgly = 0f;
        [SerializeField] private float porohPoint = 0f;
        [Space]
        [SerializeField] private float inventor = 0f;
        [SerializeField] private float limitInventore = 10f;
        [Space]
        [SerializeField] private float uran = 0f;
        [SerializeField] private float uranClear = 0f;
        [SerializeField] private float uranRadiation = 0f;
        [SerializeField] private float uranNormalRadiation;
        [Space]
        [SerializeField] private float horny = 0f;
        [Space]
        [SerializeField] private float metal = 0f;
        [SerializeField] private float metalBullet = 0f;
        [Space]
        [SerializeField] private float rubin = 0f;
        [SerializeField] private float clearRubin = 0f;
        [Space]
        [SerializeField] private float cosmo = 0f;
        [Space]
        [SerializeField] private GameObject _limitTexti;
        [Space]
        [Header("MoneyText")]
        [SerializeField] private Text moneyText;
        [SerializeField] private Text twoMoneyText;
        [SerializeField] private Text treeMoneyText;
        [Space]
        [Header("Inventore")]
        [SerializeField] private Text inventoreText;
        [SerializeField] private Text inventoreGameText;
        [SerializeField] private Text limitText;
        [SerializeField] private Text limitGameText;
        [Space]
        [Header("Uglys")]
        [SerializeField] private Text uglyText;
        [SerializeField] private Text porohText;
        [Space]
        [Header("Uranys")]
        [SerializeField] private Text uranText;
        [SerializeField] private Text claerUranText;
        [SerializeField] private Text radiathionText;
        [Space]
        [Header("Hornys")]
        [SerializeField] private Text hornyText;
        [Space]
        [Header("Metal")]
        [SerializeField] private Text metalText;
        [SerializeField] private Text inInventBullet;
        [SerializeField] private Text bulletText;
        [Space]
        [Header("Rubin")]
        [SerializeField] private Text rubinText;
        [SerializeField] private Text clearRubinText;
        [Space]
        [Header("Cosmo")]
        [SerializeField] private Text cosmoText;
        [Space]
        [Header("AI")]
        private BeeAISettings[] allBeeAISettings;

        public GameObject PanelPause { get => panelPause; set => panelPause = value; }
        public GameObject DeadPanel { get => deadPanel; set => deadPanel = value; }
        public AudioSource GameTheme { get => gameTheme; set => gameTheme = value; }
        public AudioSource Wind { get => wind; set => wind = value; }
        public AudioSource PauseTheme { get => pauseTheme; set => pauseTheme = value; }
        public bool IsPaused { get => isPaused; set => isPaused = value; }
        public float PointMoney { get => pointMoney; set => pointMoney = value; }
        public float PointUgly { get => pointUgly; set => pointUgly = value; }
        public float PorohPoint { get => porohPoint; set => porohPoint = value; }
        public float Inventor { get => inventor; set => inventor = value; }
        public float LimitInventore { get => limitInventore; set => limitInventore = value; }
        public float Uran { get => uran; set => uran = value; }
        public float UranClear { get => uranClear; set => uranClear = value; }
        public float UranRadiation { get => uranRadiation; set => uranRadiation = value; }
        public float UranNormalRadiation { get => uranNormalRadiation; set => uranNormalRadiation = value; }
        public float Horny { get => horny; set => horny = value; }
        public float Metal { get => metal; set => metal = value; }
        public float MetalBullet { get => metalBullet; set => metalBullet = value; }
        public float Rubin { get => rubin; set => rubin = value; }
        public float ClearRubin { get => clearRubin; set => clearRubin = value; }
        public float Cosmo { get => cosmo; set => cosmo = value; }
        public GameObject LimitTexti { get => _limitTexti; set => _limitTexti = value; }
        public Text MoneyText { get => moneyText; set => moneyText = value; }
        public Text TwoMoneyText { get => twoMoneyText; set => twoMoneyText = value; }
        public Text TreeMoneyText { get => treeMoneyText; set => treeMoneyText = value; }
        public Text InventoreText { get => inventoreText; set => inventoreText = value; }
        public Text InventoreGameText { get => inventoreGameText; set => inventoreGameText = value; }
        public Text LimitText { get => limitText; set => limitText = value; }
        public Text LimitGameText { get => limitGameText; set => limitGameText = value; }
        public Text UglyText { get => uglyText; set => uglyText = value; }
        public Text PorohText { get => porohText; set => porohText = value; }
        public Text UranText { get => uranText; set => uranText = value; }
        public Text ClaerUranText { get => claerUranText; set => claerUranText = value; }
        public Text RadiathionText { get => radiathionText; set => radiathionText = value; }
        public Text HornyText { get => hornyText; set => hornyText = value; }
        public Text MetalText { get => metalText; set => metalText = value; }
        public Text InInventBullet { get => inInventBullet; set => inInventBullet = value; }
        public Text BulletText { get => bulletText; set => bulletText = value; }
        public Text RubinText { get => rubinText; set => rubinText = value; }
        public Text ClearRubinText { get => clearRubinText; set => clearRubinText = value; }
        public Text CosmoText { get => cosmoText; set => cosmoText = value; }
        public BeeAISettings[] AllBeeAISettings { get => allBeeAISettings; set => allBeeAISettings = value; }

        private void Start()
        {
            Time.timeScale = 1;

            UranNormalRadiation = UranRadiation;

            IsPaused = false;

            PointMoney = 200;

            CharacterController._speed = 7f;

            Horny = 0f;
            Metal = 0f;
            MetalBullet = 0f;
            Inventor = 0f;
            LimitInventore = 10f;
            Uran = 0f;
            UranClear = 0f;
            PointUgly = 0f;
            PorohPoint = 0f;
            UranNormalRadiation = 0f;
            UranRadiation = 0f;
            ClearRubin = 0f;
            Rubin = 0f;
            Cosmo = 0f;

            MagazineWorkest._gunSold = false;
            MagazineWorkest._inventoreBigSold = false;
            MagazineWorkest._inventoreNormalSold = false;
            MagazineWorkest._petSold = false;
            MagazineWorkest._radiationSold = false;
            MagazineWorkest._speedSold = false;
            MagazineWorkest._idSold = false;
            MagazineWorkest._treckerSold = false;

            PostScript._idIsYou = false;

            LutingPlayer._heKeng = false;

        }

        private void Update()
        {
            MoneyText.text = PointMoney.ToString();
            TwoMoneyText.text = PointMoney.ToString();
            TreeMoneyText.text = PointMoney.ToString();

            if (Inventor == LimitInventore)
                Inventor = LimitInventore;

            if (DeadPlayer._isDead == true)
            {
                DeadPanel.SetActive(true);
                GameTheme.Stop();
            }

            if (PointMoney >= 1225)
                SceneManager.LoadScene(2);

            if (Inventor >= LimitInventore)
                LimitTexti.SetActive(true);
            else if (Inventor < LimitInventore)
                LimitTexti.SetActive(false);

            if (Input.GetKey(KeyCode.Escape) && LutingPlayer._isMagazineOpen == false && DeadPlayer._isDead == false && ManagerInvent._inventorOpen == false)
            {
                PanelPause.SetActive(true);
                IsPaused = true;
                GameTheme.volume = 0;
                Wind.volume = 0;
                PauseTheme.volume = 0.671f;
                Time.timeScale = 0;
            }

            if (Input.GetKeyDown(KeyCode.F8))
                SceneManager.LoadScene(1);
        }

        private void FixedUpdate()
        {
            InventoreText.text = Inventor.ToString();
            InventoreGameText.text = Inventor.ToString();
            LimitText.text = LimitInventore.ToString();
            LimitGameText.text = LimitInventore.ToString();

            UglyText.text = PointUgly.ToString();
            PorohText.text = PorohPoint.ToString();

            UranText.text = Uran.ToString();
            ClaerUranText.text = UranClear.ToString();
            RadiathionText.text = UranRadiation.ToString();

            HornyText.text = Horny.ToString();

            MetalText.text = Metal.ToString();
            BulletText.text = MetalBullet.ToString();
            InInventBullet.text = MetalBullet.ToString();

            RubinText.text = Rubin.ToString();
            ClearRubinText.text = ClearRubin.ToString();

            CosmoText.text = Cosmo.ToString();
        }
    }
}