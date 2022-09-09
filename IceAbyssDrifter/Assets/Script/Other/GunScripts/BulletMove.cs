using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletMove : MonoBehaviour
{
    [SerializeField] private float  speed;

    private bool  isRight;

    private void Start()
    {
        if (Gun. FacingRight == true)
        {
             isRight = true;
        }
        else if (Gun. FacingRight == false)
        {
             isRight = false;
        }
    }

    private void Update()
    {
        if ( isRight)
        {
            transform.Translate( speed * Time.deltaTime * Vector2.left);
        }
        else if (! isRight)
        {
            transform.Translate( speed * Time.deltaTime * Vector2.right);
        }
    }
}