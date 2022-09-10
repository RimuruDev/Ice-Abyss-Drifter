using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAI : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _distance;
    [SerializeField] float _startWaitTime;

    public static AudioSource _theefy;

    private bool _isTheef = false;
    private bool _isDagry = false;

    private float _waitTime;
    private int _randomPoint;

    void Start()
    {
        _randomPoint = Random.Range(0, TransformPoint._points.Length);
        _isDagry = false;
        _isTheef = false;
        _waitTime = _startWaitTime;
        StartCoroutine("Theef");
    }

    void FixedUpdate()
    {
        if (_isDagry == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, TransformPoint._points[_randomPoint].position, _speed * Time.deltaTime);
            _FlipWithPoints();
            if (Vector2.Distance(transform.position, TransformPoint._points[_randomPoint].position) < 0.2f)
            {            
                if (_waitTime <= 0)
                {
                    _randomPoint = Random.Range(0, TransformPoint._points.Length);
                    _waitTime = _startWaitTime;
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
        }

        if (_isTheef == true && Vector2.Distance(transform.position, PlayerControl._playerPoint.transform.position) < _distance && LutingPlayer._heKeng == false)
        {
            _isDagry = true;
            transform.position = Vector2.MoveTowards(transform.position, PlayerControl._playerPoint.transform.position, _speed * Time.deltaTime);
            _FlipWithPlayer();
        }
        else if (Vector2.Distance(transform.position, PlayerControl._playerPoint.transform.position) > _distance)
        {   
            _isDagry = false;
        }
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_isDagry == true && _coll.gameObject.CompareTag("Player") && _isTheef == true)
        {
            GameManager._pointMoney -= 100f;
            _theefy.Play();
            _speed += 3f;
            _isDagry = false;
            _isTheef = false;
            StartCoroutine("Theef");
            StartCoroutine("SpeedNormal");
        }
    }

    void _FlipWithPoints()
    {
        if (TransformPoint._points[_randomPoint].transform.position.x < transform.position.x)
        {
           transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (TransformPoint._points[_randomPoint].transform.position.x > transform.position.x)
        {
          transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void _FlipWithPlayer()
    {
        if (PlayerControl._playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (PlayerControl._playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    IEnumerator Theef()
    {
        yield return new WaitForSeconds(45);
        _isTheef = true;
    }

    IEnumerator SpeedNormal()
    {
        yield return new WaitForSeconds(3);
        _speed -= 3f;
    }
}
