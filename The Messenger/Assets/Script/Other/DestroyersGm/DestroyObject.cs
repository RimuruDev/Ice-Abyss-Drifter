using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] GameObject _effectUran;
    [SerializeField] GameObject _effectUgly;
    [SerializeField] GameObject _effectGold;
    [SerializeField] GameObject _effectMetal;
    [SerializeField] GameObject _effectHorny;
    [SerializeField] GameObject _effectRubin;
    [SerializeField] GameObject _effectCosmo;

    [Header("Bools")]
    [SerializeField] bool _isUgly;
    [SerializeField] bool _isMetal;
    [SerializeField] bool _isGold;
    [SerializeField] bool _isUran;
    [SerializeField] bool _isHorny;
    [SerializeField] bool _isRubin;
    [SerializeField] bool _isCosmo;

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Player"))
        {
            if (_isUran == true)
            {
                Instantiate(_effectUran, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (_isUgly == true)
            {
                Instantiate(_effectUgly, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (_isMetal == true)
            {
                Instantiate(_effectMetal, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (_isHorny == true)
            {
                Instantiate(_effectHorny, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (_isGold == true)
            {
                Instantiate(_effectGold, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (_isRubin == true)
            {
                Instantiate(_effectRubin, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (_isCosmo == true)
            {
                Instantiate(_effectCosmo, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if ( _coll.gameObject.CompareTag("Sold") || _coll.gameObject.CompareTag("Raport") || _coll.gameObject.CompareTag("Magas"))
        {
            Destroy(gameObject);
        }
    }
}
