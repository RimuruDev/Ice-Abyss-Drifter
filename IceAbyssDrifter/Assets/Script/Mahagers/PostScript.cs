using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostScript : MonoBehaviour
{
    [SerializeField] GameObject _gun;

    [SerializeField] GameObject _petHappy;
    [SerializeField] GameObject _petNormal;
    [SerializeField] GameObject _petSad;

    [SerializeField] GameObject _ID;

    [SerializeField] AudioSource _sound;

    [Header("Bools")]
    [SerializeField] bool _isSpeed;
    [SerializeField] bool _isRadiation;
    [SerializeField] bool _isNormalInventore;
    [SerializeField] bool _isBigInventore;
    [SerializeField] bool _isPet;
    [SerializeField] bool _isGun;
    [SerializeField] bool _isID;
    [SerializeField] bool _isTrecker;

    public static bool _isSpeedy;

    public static bool _idIsYou = false;

    private void Start()
    {
        transform.position = new Vector2(Random.Range(-110, 110), Random.Range(10, 70));
        _isSpeedy = false;
    }

    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Player"))
        {
            if (_isSpeed == true && MagazineWorkest._speedSold == true)
            {
                CharacterController._speed = 9f;
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                Destroy(gameObject);
            }

            if (_isRadiation == true && MagazineWorkest._radiationSold == true)
            {
                GameManager._uranNormalRadiation = 150f;
                GameManager._uranRadiation = 150f;
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                Destroy(gameObject);
            }

            if (_isNormalInventore == true && MagazineWorkest._inventoreNormalSold == true)
            {
                GameManager._limitInventore += 15f;
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                Destroy(gameObject);
            }

            if (_isBigInventore == true && MagazineWorkest._inventoreBigSold == true)
            {
                GameManager._limitInventore += 25f;
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                Destroy(gameObject);
            }

            if (_isGun == true && MagazineWorkest._gunSold == true)
            {
                _gun.SetActive(true);
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                Destroy(gameObject);
            }

            if (_isPet == true && MagazineWorkest._petSold == true)
            {
                float _randomPet = Random.Range(1, 4);
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                switch (_randomPet)
                {
                    case 1:
                    Instantiate(_petSad, gameObject.transform.position, Quaternion.identity);
                    break;

                    case 2:
                    Instantiate(_petNormal, gameObject.transform.position, Quaternion.identity);
                    break;

                    case 3:
                    Instantiate(_petHappy, gameObject.transform.position, Quaternion.identity);
                    break;
                }
                Destroy(gameObject);
            }

            if (_isID == true && MagazineWorkest._idSold == true)
            {
                _ID.SetActive(true);
                _idIsYou = true;
                _sound.pitch = Random.Range(0.8f, 1f);
                _sound.Play();
                Destroy(gameObject);
            }
        }
    }
}
