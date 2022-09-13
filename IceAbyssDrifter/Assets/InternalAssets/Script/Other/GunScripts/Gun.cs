using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float _offset;
    public static bool _FacingRight;

    [SerializeField] GameObject _effectShot;

    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _shotPos;

    [SerializeField] AudioSource _shotSound;

    [SerializeField] float _timeStart;
    private float _timeShot;

    void Update()
    {
        if (LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        {
            if (GameManager._metalBullet >= 1f)
            {
                if (_timeShot <= 0f)
                {
                    if (Input.GetMouseButtonDown(0))
                    {  
                        Instantiate(_bullet, _shotPos.position, transform.rotation);
                        Instantiate(_effectShot, _shotPos.transform.position, transform.rotation);
                        _shotSound.pitch = Random.Range(0.7f, 1f); 
                        _shotSound.Play();
                        GameManager._metalBullet -= 1f;
                        _timeShot = _timeStart;    
                    }
                }
                else
                {
                    _timeShot -= Time.deltaTime; 
                }
            }
        }
        else
        {
            _timeShot -= Time.deltaTime; 
        }

        if (DeadPlayer._isDead == true)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float _rotateZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _rotateZ + _offset);

        if (_difference.x > 0 && _FacingRight)
        {
            Flip();
            _offset = 0;
        }
        else if (_difference.x < 0 && !_FacingRight)
        {
            Flip();
            _offset = 180f;
        }
    }

    void Flip()
    {
        _FacingRight = !_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
