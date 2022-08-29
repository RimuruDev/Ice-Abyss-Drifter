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

        private void Start()
        {
            Time.timeScale = 1;

            uranNormalRadiation = uranRadiation;

            isPaused = false;

            pointMoney = 200;

            CharacterController._speed = 7f;

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
            moneyText.text = pointMoney.ToString();
            twoMoneyText.text = pointMoney.ToString();
            treeMoneyText.text = pointMoney.ToString();

            if (inventor == limitInventore)
                inventor = limitInventore;

            if (DeadPlayer._isDead == true)
            {
                deadPanel.SetActive(true);
                gameTheme.Stop();
            }

            if (pointMoney >= 1225)
                SceneManager.LoadScene(2);

            if (inventor >= limitInventore)
                _limitTexti.SetActive(true);
            else if (inventor < limitInventore)
                _limitTexti.SetActive(false);

            if (Input.GetKey(KeyCode.Escape) && LutingPlayer._isMagazineOpen == false && DeadPlayer._isDead == false && ManagerInvent._inventorOpen == false)
            {
                panelPause.SetActive(true);
                isPaused = true;
                gameTheme.volume = 0;
                wind.volume = 0;
                pauseTheme.volume = 0.671f;
                Time.timeScale = 0;
            }

            if (Input.GetKeyDown(KeyCode.F8))
                SceneManager.LoadScene(1);
        }

        private void FixedUpdate()
        {
            inventoreText.text = inventor.ToString();
            inventoreGameText.text = inventor.ToString();
            limitText.text = limitInventore.ToString();
            limitGameText.text = limitInventore.ToString();

            uglyText.text = pointUgly.ToString();
            porohText.text = porohPoint.ToString();

            uranText.text = uran.ToString();
            claerUranText.text = uranClear.ToString();
            radiathionText.text = uranRadiation.ToString();

            hornyText.text = horny.ToString();

            metalText.text = metal.ToString();
            bulletText.text = metalBullet.ToString();
            inInventBullet.text = metalBullet.ToString();

            rubinText.text = rubin.ToString();
            clearRubinText.text = clearRubin.ToString();

            cosmoText.text = cosmo.ToString();
        }
    }
}