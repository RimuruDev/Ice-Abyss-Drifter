using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float _speed;

    bool _isRight;

    void Start()
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
         
    void Update()
    {
        if (_isRight)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else if (!_isRight)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }     
}
