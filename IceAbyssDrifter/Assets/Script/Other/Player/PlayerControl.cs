using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    [SerializeField] float _speedFactor;
    [SerializeField] Transform _player;

    [SerializeField] GameObject _effectTeleport;

    [SerializeField] Text _textX;
    [SerializeField] Text _textY;

    [SerializeField] Transform[] _pointStart;
    private int _random;

    private bool _FacingRight;

    public static float _speed = 7f;
    public static Transform _playerPoint;

    private int _xDerect;
    private int _yDerect;

    private float _timeStart = 7f;
    private float _timeShot = 7f;

    Rigidbody2D _rb;
    Vector2 _movement;

    void Awake()
    {
        _timeStart = Random.Range(5, 12);
        _timeShot = _timeStart;
        _random = Random.Range(0, _pointStart.Length);
        _speed = _speedFactor;
        _rb = GetComponent<Rigidbody2D>();
        transform.position = _pointStart[_random].transform.position;
    }

    void FixedUpdate()
    {
        _movement.x = joystick.Horizontal;
        _movement.y = joystick.Vertical;

        _speedFactor = _speed;

        _xDerect = ((int)transform.position.x);
        _yDerect = ((int)transform.position.y);

        _textX.text = _xDerect.ToString() + " :X";
        _textY.text = _yDerect.ToString() + " :Y";

        _playerPoint = _player;

        if (_movement.x < 0 && _FacingRight)
        {
            Flip();
        }
        else if (_movement.x >  0 && !_FacingRight)
        {
            Flip();
        }

        if (GameManager._cosmo >= 1f)
        {
            if (_timeShot <= 0f)
            {
                transform.position = new Vector2(Random.Range(110, -110), Random.Range(70, -25));
                _timeStart = Random.Range(5, 12);
                Instantiate(_effectTeleport, gameObject.transform.position, Quaternion.identity);
                _timeShot = _timeStart;
            }
            else
            {
                _timeShot -= Time.deltaTime;
            }
        }

        _rb.MovePosition(_rb.position +_movement * _speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        _FacingRight = !_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
