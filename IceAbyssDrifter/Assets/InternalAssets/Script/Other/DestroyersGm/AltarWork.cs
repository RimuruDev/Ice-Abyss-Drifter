using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltarWork : MonoBehaviour
{
    [SerializeField] GameObject _effectAltar;

    [SerializeField] GameObject _heartImage;
    [SerializeField] GameObject _south;

    [SerializeField] AudioSource _aktiv;

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Player") && SouthPickUp._isPick == true)
        { 
            Instantiate(_effectAltar, gameObject.transform.position, Quaternion.identity);
            _south.SetActive(false);
            _aktiv.Play();
            _heartImage.SetActive(true);
            SouthPickUp._isLive = true;
            SouthPickUp._isPick = false;
            Destroy(gameObject);
        }
    }
}
