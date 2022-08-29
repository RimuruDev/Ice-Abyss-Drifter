using RimuruDev.AI;
using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class BeeAI : MonoBehaviour
    {
        [SerializeField] private BeePointArray beeTransformPoints;

        [SerializeField] float _speed;
        [SerializeField] float _startWaitTime;
        [SerializeField] float _minDistance;

        [SerializeField] bool _isBee;

        private bool _isAgry = false;
        private float _waitTime;
        private int _randomPoint;

        private void Awake()
        {
            if (beeTransformPoints == null)
                beeTransformPoints = FindObjectOfType<BeePointArray>();
        }

        private void Start()
        {
            _randomPoint = Random.Range(0, beeTransformPoints.BeeMovementPoints.Length);

            _waitTime = _startWaitTime;
        }

        private void FixedUpdate()
        {
            if (_isAgry == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, beeTransformPoints.BeeMovementPoints[_randomPoint].position, _speed * Time.deltaTime);

                _FlipWithPoints();

                if (Vector2.Distance(transform.position, beeTransformPoints.BeeMovementPoints[_randomPoint].position) < 0.2f)
                {

                    if (_waitTime <= 0)
                    {
                        _randomPoint = Random.Range(0, beeTransformPoints.BeeMovementPoints.Length);
                        _waitTime = _startWaitTime;
                    }
                    else
                    {
                        _waitTime -= Time.deltaTime;
                    }
                }
            }

            if (Vector2.Distance(transform.position, CharacterController._playerPoint.transform.position) < _minDistance)
            {
                _isAgry = true;
                if (_isAgry == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, CharacterController._playerPoint.transform.position, _speed * Time.deltaTime);
                    _FlipWithPlayer();
                }
            }
            else if (Vector2.Distance(transform.position, CharacterController._playerPoint.transform.position) > _minDistance)
            {
                _isAgry = false;
            }

            if (LutingPlayer._heKeng == true)
            {
                _minDistance = 0f;
            }

            if (_isBee == true && LutingPlayer._heKeng == false)
            {
                if (GameManager._horny <= 0f)
                {
                    _minDistance = 0f;
                }
                else if (GameManager._horny >= 1f)
                {
                    _minDistance = 5f;
                }
            }
            else if (_isBee == false && LutingPlayer._heKeng == false)
            {
                if (GameManager._metal >= 1f || GameManager._uran >= 1f || GameManager._horny >= 1f || GameManager._pointUgly >= 1f || GameManager._uranClear >= 1f || GameManager._porohPoint >= 1f || GameManager._metalBullet >= 1f || GameManager._clearRubin >= 1f || GameManager._rubin >= 1f)
                {
                    _minDistance = 7f;
                }
                else if (GameManager._metal <= 0f && GameManager._uran <= 0f && GameManager._horny <= 0f && GameManager._pointUgly <= 0f && GameManager._uranClear <= 0f && GameManager._porohPoint <= 0f && GameManager._metalBullet <= 0f && GameManager._rubin <= 0f && GameManager._clearRubin <= 0f)
                {
                    _minDistance = 0f;
                }
            }
        }

        private void _FlipWithPlayer()
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

        private void _FlipWithPoints()
        {
            if (beeTransformPoints.BeeMovementPoints[_randomPoint].transform.position.x < transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (beeTransformPoints.BeeMovementPoints[_randomPoint].transform.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}