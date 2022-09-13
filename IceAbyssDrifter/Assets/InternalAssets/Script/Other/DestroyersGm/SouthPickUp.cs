using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthPickUp : MonoBehaviour
{
    public static bool _isPick;
    public static bool _isLive;

    [SerializeField] GameObject _south; 

    [SerializeField] AudioSource _southPick;

    void Start()
    {
        _isPick = false;
        _isLive = false;
        
        transform.position = new Vector2(Random.Range(-110, 110), Random.Range(70, -25));  
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Player"))
        {
            _isPick = true;
            _southPick.Play();
            _south.SetActive(true);
            Destroy(gameObject);
        }
    }
}
