using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _panelPause;

    [SerializeField] GameObject _deadPanel;

    [SerializeField] AudioSource _gameTheme;
    [SerializeField] AudioSource _wind;
    [SerializeField] AudioSource _pauseTheme;

    public static bool _isPaused = false;

    public static float _pointMoney = 653;

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

    public static float _terrakota = 0f;

    public static float _moon = 0f;
    public static float _moonDirt = 0f;

    [SerializeField] GameObject _limitTexti;

    [Header("MoneyText")]
    [SerializeField] Text _moneyText;
    [SerializeField] Text _twoMoneyText;
    [SerializeField] Text _treeMoneyText;

    [Header("Inventore")]
    [SerializeField] Text _inventoreText;
    [SerializeField] Text _inventoreGameText;
    [SerializeField] Text _limitText;
    [SerializeField] Text _limitGameText;

    [Header("Uglys")]
    [SerializeField] Text _uglyText;
    [SerializeField] Text _porohText;

    [Header("Uranys")]
    [SerializeField] Text _uranText;
    [SerializeField] Text _claerUranText;
    [SerializeField] Text _radiathionText; 

    [Header("Hornys")]
    [SerializeField] Text _hornyText;

    [Header("Metal")]
    [SerializeField] Text _metalText;
    [SerializeField] Text _inInventBullet;
    [SerializeField] Text _bulletText;

    [Header("Rubin")]
    [SerializeField] Text _rubinText;
    [SerializeField] Text _clearRubinText;

    [Header("Cosmo")]
    [SerializeField] Text _cosmoText;

    [Header("Terrakota")]
    [SerializeField] Text _terrakotaText;

    [Header("Moon")]
    [SerializeField] Text _moonText;
    [SerializeField] Text _moonDirtText;

    void Start()
    {
        Time.timeScale = 1;

        _uranNormalRadiation = _uranRadiation;

        _isPaused = false;

        _pointMoney = 20f;

        PlayerControl._speed = 7f;

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
        _terrakota = 0f;
        _moon = 0f;
        _moonDirt = 0f;

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

    void Update()
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

        if (_pointMoney <= -1f)
        {
            _pointMoney = 0f;
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

    void FixedUpdate()
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

        _terrakotaText.text = _terrakota.ToString();

        _moonText.text = _moon.ToString();
        _moonDirtText.text = _moonDirt.ToString();
    }
}
