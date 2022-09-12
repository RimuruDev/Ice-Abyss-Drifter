using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RimuruDev;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private WorldPontArray worldPontArray;

    [SerializeField] float _speed;
    [SerializeField] float _startWaitTime;
    [SerializeField] float _minDistance;

    private bool _isAgry = false;
    private float _waitTime;
    private int _randomPoint;

    private void Awake()
    {
        if (worldPontArray == null)
            worldPontArray = FindObjectOfType<WorldPontArray>();
    }

    void Start()
    {
        _randomPoint = Random.Range(0, worldPontArray.WorldMovementPoints.Length);
        _waitTime = _startWaitTime;
    }

    void FixedUpdate()
    {

        if (_isAgry == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, worldPontArray.WorldMovementPoints[_randomPoint].position, _speed * Time.deltaTime);
            _FlipWithPoints();
            if (Vector2.Distance(transform.position, worldPontArray.WorldMovementPoints[_randomPoint].position) < 0.2f)
            {
               
               if (_waitTime <= 0)
               {
                 _randomPoint = Random.Range(0, worldPontArray.WorldMovementPoints.Length);
                 _waitTime = _startWaitTime;
               }
               else
               {
                 _waitTime -= Time.deltaTime;
               }
            }
        }

        if (PlayerControl._playerPoint == null) return;

        if (Vector2.Distance(transform.position, PlayerControl._playerPoint.transform.position) < _minDistance && LutingPlayer._heKeng == false)
        {
            _isAgry = true;
            if (_isAgry == true)
            {
               transform.position = Vector2.MoveTowards(transform.position, PlayerControl._playerPoint.transform.position, _speed * Time.deltaTime);
               _FlipWithPlayer();
            }
        }
        else if (Vector2.Distance(transform.position, PlayerControl._playerPoint.transform.position) > _minDistance)
        {
          _isAgry = false;
        }

        if (LutingPlayer._heKeng == true)
        {
            _minDistance = 0f;
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

    void _FlipWithPoints()
    {
        if (worldPontArray.WorldMovementPoints[_randomPoint].transform.position.x < transform.position.x)
        {
           transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (worldPontArray.WorldMovementPoints[_randomPoint].transform.position.x > transform.position.x)
        {
          transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
