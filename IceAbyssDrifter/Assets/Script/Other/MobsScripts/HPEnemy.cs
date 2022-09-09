using RimuruDev;
using UnityEngine;

public sealed class HPEnemy : MonoBehaviour
{
    private GameDataContainer dataContainer;
    [SerializeField] private float _health;
    private float _Nhealth;

    [SerializeField] private bool _isKing = false;
    [SerializeField] private GameObject _cloud;
    [SerializeField] private GameObject _king;
    [SerializeField] private GameObject _flex;

    [SerializeField] private GameObject _effectEnemy;
    [SerializeField] private GameObject _blood;

    [SerializeField] private bool _isBee;
    [SerializeField] private bool _isUlitka;
    [SerializeField] private bool _isSheep;
    [SerializeField] private bool _isBuka;
    [SerializeField] private bool _isCat;
    [SerializeField] private bool _isMohan;
    [SerializeField] private bool _isActivator;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();

        _Nhealth = _health;
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        _health -= 1f;

        Instantiate(_effectEnemy, gameObject.transform.position, Quaternion.identity);

        if (_health <= 0f)
        {
            Destroy(gameObject);
            Instantiate(_blood, gameObject.transform.position, Quaternion.identity);

            _health = _Nhealth;

            if (_isKing == true)
            {
                Instantiate(_flex, gameObject.transform.position, Quaternion.identity);
                Instantiate(_cloud, gameObject.transform.position, Quaternion.identity);
            }

            if (_isActivator == true && LutingPlayer._heKeng == false)
            {
                Instantiate(_king, gameObject.transform.position, Quaternion.identity);
            }

            if (MagazineWorkest._idSold == true && PostScript._idIsYou == true)
            {
                if (_isBee == true)
                {
                    dataContainer.PointMoney += 50f;
                }

                if (_isUlitka == true)
                {
                    dataContainer.PointMoney += 30f;
                }

                if (_isBuka == true)
                {
                    dataContainer.PointMoney += 20f;
                }

                if (_isSheep == true)
                {
                    dataContainer.PointMoney += 80f;
                }

                if (_isMohan == true)
                {
                    dataContainer.PointMoney += 150f;
                }

                if (_isCat == true)
                {
                    dataContainer.PointMoney += 56f;
                }

                if (_isActivator == true)
                {
                    dataContainer.PointMoney += 300f;
                }

                if (_isKing == true)
                {
                    dataContainer.PointMoney += 200f;
                }
            }
        }
    }
}