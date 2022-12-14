using RimuruDev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    private GenerationRandomText generationRandomText = null;

    public static bool _isDead = false;

    [SerializeField] GameObject _gun;
    [SerializeField] GameObject _heartImage;
    [SerializeField] AudioSource _teleportLife;

    [SerializeField] GameObject _effectsTep;

    private void Awake()
    {
        generationRandomText = FindObjectOfType<GenerationRandomText>();
    }

    void Start()
    {
        _isDead = false;
    }

    void Update()
    {
        if (_isDead == true)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Enemy") && LutingPlayer._heKeng == false && SouthPickUp._isLive == false)
        {
            Destroy(gameObject);
            Destroy(_gun);
            _isDead = true;

            generationRandomText.SetAfterDeatText((Random.Range(0, generationRandomText.GetAfterDefeatTextLength)));
        }

        if (_coll.gameObject.CompareTag("Enemy") && SouthPickUp._isLive == true)
        {
            transform.position = new Vector2(Random.Range(-110, 110), Random.Range(70, -25)); 
            Instantiate(_effectsTep, gameObject.transform.position, Quaternion.identity);
            _teleportLife.Play();
            _heartImage.SetActive(false);
            SouthPickUp._isLive = false;

            generationRandomText.SetAfterDeatText((Random.Range(0, generationRandomText.GetAfterDefeatTextLength)));
        }
    }
}
