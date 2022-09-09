using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class BeeAI : MonoBehaviour
    {
        private GameDataContainer dataContainer;

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
            dataContainer = FindObjectOfType<GameDataContainer>();

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

                FlipWithPoints();

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
                    FlipWithPlayer();
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
                if (dataContainer.Horny <= 0f)
                {
                    _minDistance = 0f;
                }
                else if (dataContainer.Horny >= 1f)
                {
                    _minDistance = 5f;
                }
            }
            else if (_isBee == false && LutingPlayer._heKeng == false)
            {
                if (dataContainer.Metal >= 1f || dataContainer.Uran >= 1f || dataContainer.Horny >= 1f || dataContainer.PointUgly >= 1f || dataContainer.UranClear >= 1f || dataContainer.PorohPoint >= 1f || dataContainer.MetalBullet >= 1f || dataContainer.ClearRubin >= 1f || dataContainer.Rubin >= 1f)
                {
                    _minDistance = 7f;
                }
                else if (dataContainer.Metal <= 0f && dataContainer.Uran <= 0f && dataContainer.Horny <= 0f && dataContainer.PointUgly <= 0f && dataContainer.UranClear <= 0f && dataContainer.PorohPoint <= 0f && dataContainer.MetalBullet <= 0f && dataContainer.Rubin <= 0f && dataContainer.ClearRubin <= 0f)
                {
                    _minDistance = 0f;
                }
            }
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