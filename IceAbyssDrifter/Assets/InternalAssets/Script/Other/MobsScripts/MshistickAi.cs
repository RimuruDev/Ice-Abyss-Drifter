using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MshistickAi : MonoBehaviour
{
    [SerializeField] float _speed;

    [SerializeField] float _startWaitTime;

    [SerializeField] GameObject _fakeCust;
    [SerializeField] GameObject _effectCustSpawn;
    [SerializeField] GameObject _effectCustDone;

    private float _waitTime;
    private int _randomPoint;

    private bool _isBuilding;

    void Start()
    {
        _isBuilding = false;
        StartCoroutine("BuildStart");
    }

    void FixedUpdate()
    {
        if (_isBuilding == false)
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

    IEnumerator BuildStart()
    {
        yield return new WaitForSeconds(40);
        Instantiate(_effectCustSpawn, gameObject.transform.position, Quaternion.identity);
        _isBuilding = true;
        _speed = 0f;
        StartCoroutine("BuildDone");
        StopCoroutine("BuildStart");
    }

    IEnumerator BuildDone()
    {
        yield return new WaitForSeconds(10);
        _speed = 3f;
        Instantiate(_effectCustDone, gameObject.transform.position, Quaternion.identity);
        Instantiate(_fakeCust, gameObject.transform.position, Quaternion.identity);
        _isBuilding = false;
        StartCoroutine("BuildStart");
        StopCoroutine("BuildDone");
    }
}
