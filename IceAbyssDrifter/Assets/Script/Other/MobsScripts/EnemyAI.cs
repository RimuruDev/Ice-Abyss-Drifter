using RimuruDev.AI;
using UnityEngine;

public sealed class EnemyAI : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _startWaitTime;
    [SerializeField] float _minDistance;

    private bool _isAgry = false;
    private float _waitTime;
    private int _randomPoint;

    private AllMobMovementPoints allMobPoints = null;

    private void Awake()
    {
        allMobPoints = FindObjectOfType<AllMobMovementPoints>();
    }

    private void Start()
    {
        _randomPoint = Random.Range(0, allMobPoints.AllPoints.Length);

        _waitTime = _startWaitTime;
    }

    private void FixedUpdate()
    {

        if (_isAgry == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, allMobPoints.AllPoints[_randomPoint].position, _speed * Time.deltaTime);
            FlipWithPoints();
            if (Vector2.Distance(transform.position, allMobPoints.AllPoints[_randomPoint].position) < 0.2f)
            {

                if (_waitTime <= 0)
                {
                    _randomPoint = Random.Range(0, allMobPoints.AllPoints.Length);
                    _waitTime = _startWaitTime;
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
        }

        if (Vector2.Distance(transform.position, CharacterController._playerPoint.transform.position) < _minDistance && LutingPlayer._heKeng == false)
        {
            _isAgry = true;

            if (_isAgry)
            {
                transform.position = Vector2.MoveTowards(transform.position, CharacterController._playerPoint.transform.position, _speed * Time.deltaTime);

                FlipWithPlayer();
            }
        }
        else if (Vector2.Distance(transform.position, CharacterController._playerPoint.transform.position) > _minDistance)
        {
            _isAgry = false;
        }

        if (LutingPlayer._heKeng)
            _minDistance = 0f;
    }

    private void FlipWithPlayer()
    {
        if (CharacterController._playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (CharacterController._playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void FlipWithPoints()
    {
        if (allMobPoints.AllPoints[_randomPoint].transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (allMobPoints.AllPoints[_randomPoint].transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
