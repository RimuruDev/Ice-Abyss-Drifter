using RimuruDev.Mechanics.Character;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelPause;

    [SerializeField] private GameObject _deadPanel;

    [SerializeField] private AudioSource _gameTheme;
    [SerializeField] private AudioSource _wind;
    [SerializeField] private AudioSource _pauseTheme;

    public static bool _isPaused = false;

    public static float _pointMoney = 20f;

    public static float _pointUgly = 0f;
    public static float _porohPoint = 0f;

    public static float _inventor = 0f;
    public static float _limitInventore = 10f;

    public static float _uran = 0f;
    public static float _uranClear = 0f;
    public static float _uranRadiation = 0f;
    public static float _uranNormalRadiation;

    public static float _horny = 0f;

    public static float _metal = 0f;
    public static float _metalBullet = 0f;

    public static float _rubin = 0f;
    public static float _clearRubin = 0f;

    public static float _cosmo = 0f;

    [SerializeField] private GameObject _limitTexti;

    [Header("MoneyText")]
    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _twoMoneyText;
    [SerializeField] private Text _treeMoneyText;

    [Header("Inventore")]
    [SerializeField] private Text _inventoreText;
    [SerializeField] private Text _inventoreGameText;
    [SerializeField] private Text _limitText;
    [SerializeField] private Text _limitGameText;

    [Header("Uglys")]
    [SerializeField] private Text _uglyText;
    [SerializeField] private Text _porohText;

    [Header("Uranys")]
    [SerializeField] private Text _uranText;
    [SerializeField] private Text _claerUranText;
    [SerializeField] private Text _radiathionText;

    [Header("Hornys")]
    [SerializeField] private Text _hornyText;

    [Header("Metal")]
    [SerializeField] private Text _metalText;
    [SerializeField] private Text _inInventBullet;
    [SerializeField] private Text _bulletText;

    [Header("Rubin")]
    [SerializeField] private Text _rubinText;
    [SerializeField] private Text _clearRubinText;

    [Header("Cosmo")]
    [SerializeField] private Text _cosmoText;

    private void Start()
    {
        Time.timeScale = 1;

        _uranNormalRadiation = _uranRadiation;

        _isPaused = false;

        _pointMoney = 200;

        CharacterController._speed = 7f;

        _horny = 0f;
        _metal = 0f;
        _metalBullet = 0f;
        _inventor = 0f;
        _limitInventore = 10f;
        _uran = 0f;
        _uranClear = 0f;
        _pointUgly = 0f;
        _porohPoint = 0f;
        _uranNormalRadiation = 0f;
        _uranRadiation = 0f;
        _clearRubin = 0f;
        _rubin = 0f;
        _cosmo = 0f;

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
        _moneyText.text = _pointMoney.ToString();
        _twoMoneyText.text = _pointMoney.ToString();
        _treeMoneyText.text = _pointMoney.ToString();

        if (_inventor == _limitInventore)
        {
            _inventor = _limitInventore;
        }

        if (DeadPlayer._isDead == true)
        {
            _deadPanel.SetActive(true);
            _gameTheme.Stop();
        }

        if (_pointMoney >= 1225)
        {
            SceneManager.LoadScene(2);
        }

        if (_inventor >= _limitInventore)
        {
            _limitTexti.SetActive(true);
        }
        else if (_inventor < _limitInventore)
        {
            _limitTexti.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Escape) && LutingPlayer._isMagazineOpen == false && DeadPlayer._isDead == false && ManagerInvent._inventorOpen == false)
        {
            _panelPause.SetActive(true);
            _isPaused = true;
            _gameTheme.volume = 0;
            _wind.volume = 0;
            _pauseTheme.volume = 0.671f;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void FixedUpdate()
    {
        _inventoreText.text = _inventor.ToString();
        _inventoreGameText.text = _inventor.ToString();
        _limitText.text = _limitInventore.ToString();
        _limitGameText.text = _limitInventore.ToString();

        _uglyText.text = _pointUgly.ToString();
        _porohText.text = _porohPoint.ToString();

        _uranText.text = _uran.ToString();
        _claerUranText.text = _uranClear.ToString();
        _radiathionText.text = _uranRadiation.ToString();

        _hornyText.text = _horny.ToString();

        _metalText.text = _metal.ToString();
        _bulletText.text = _metalBullet.ToString();
        _inInventBullet.text = _metalBullet.ToString();

        _rubinText.text = _rubin.ToString();
        _clearRubinText.text = _clearRubin.ToString();

        _cosmoText.text = _cosmo.ToString();
    }
}