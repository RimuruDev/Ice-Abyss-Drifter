using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class DestroyObject : MonoBehaviour
    {
        [Header("Effects")]
        [SerializeField] private GameObject _effectUran;
        [SerializeField] private GameObject _effectUgly;
        [SerializeField] private GameObject _effectGold;
        [SerializeField] private GameObject _effectMetal;
        [SerializeField] private GameObject _effectHorny;
        [SerializeField] private GameObject _effectRubin;
        [SerializeField] private GameObject _effectCosmo;
        [SerializeField] private GameObject _effectTerrakota;
        [SerializeField] private GameObject _effectMoon;

        [Header("Bools")]
        [SerializeField] private bool _isUgly;
        [SerializeField] private bool _isMetal;
        [SerializeField] private bool _isGold;
        [SerializeField] private bool _isUran;
        [SerializeField] private bool _isHorny;
        [SerializeField] private bool _isRubin;
        [SerializeField] private bool _isCosmo;
        [SerializeField] private bool _isTerrakota;
        [SerializeField] private bool _isMoon;

        private void OnTriggerEnter2D(Collider2D _coll)
        {
            //     if (_coll.CompareTag("Player"))
            //      {
            //foreach (var item in collection)
            //{

            //}
            //     }

            //    if (_coll.gameObject.CompareTag("Player"))
            //     {
            //Destroy(gameObject);
            //if (_isUran == true)
            //{
            //    Instantiate(_effectUran, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isUgly == true)
            //{
            //    Instantiate(_effectUgly, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isMetal == true)
            //{
            //    Instantiate(_effectMetal, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isHorny == true)
            //{
            //    Instantiate(_effectHorny, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isGold == true)
            //{
            //    Instantiate(_effectGold, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isRubin == true)
            //{
            //    Instantiate(_effectRubin, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isCosmo == true)
            //{
            //    Instantiate(_effectCosmo, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isTerrakota == true)
            //{
            //    Instantiate(_effectTerrakota, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //else if (_isMoon == true)
            //{
            //    Instantiate(_effectMoon, gameObject.transform.position, Quaternion.identity);
            //    Destroy(gameObject);
            //}
            //    }

            if (_coll.gameObject.CompareTag("Sold") || _coll.gameObject.CompareTag("Raport") || _coll.gameObject.CompareTag("Magas"))
            {
                Destroy(gameObject);
            }
        }
    }
}