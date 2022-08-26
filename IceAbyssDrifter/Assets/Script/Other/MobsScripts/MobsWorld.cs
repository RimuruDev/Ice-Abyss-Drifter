using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsWorld : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _startWaitTime;

    private float _waitTime;
    private int _randomPoint;

    void Start()
    {
        _randomPoint = Random.Range(0, TransformPoint._points.Length);
        _waitTime = _startWaitTime;
    }

    void FixedUpdate()
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
}
