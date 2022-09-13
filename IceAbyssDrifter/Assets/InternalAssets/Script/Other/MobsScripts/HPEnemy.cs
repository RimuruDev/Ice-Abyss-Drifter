using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPEnemy : MonoBehaviour
{
    [SerializeField] float _health;
    private float _Nhealth;

    [SerializeField] float _plusMoney;

    [SerializeField] bool _isKing = false;
    [SerializeField] GameObject _cloud;
    [SerializeField] GameObject _king;
    [SerializeField] GameObject _flex;

    [SerializeField] GameObject _effectEnemy;
    [SerializeField] GameObject _blood;

    [SerializeField] bool _isActivator;

    void Awake()
    {
        _Nhealth = _health;
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
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
                GameManager._pointMoney += _plusMoney;
            }
        }
    }
}
