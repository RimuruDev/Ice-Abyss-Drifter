using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isRight;

    private void Start()
    {
        if (Gun._FacingRight == true)
        {
            _isRight = true;
        }
        else if (Gun._FacingRight == false)
        {
            _isRight = false;
        }
    }

    private void Update()
    {
        if (_isRight)
        {
            transform.Translate(_speed * Time.deltaTime * Vector2.left);
        }
        else if (!_isRight)
        {
            transform.Translate(_speed * Time.deltaTime * Vector2.right);
        }
    }
}