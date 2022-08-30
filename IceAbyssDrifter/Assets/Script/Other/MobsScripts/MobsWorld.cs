using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class MobsWorld : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _startWaitTime;

        private float _waitTime;
        private int _randomPoint;

        private WorldPontArray worldPont;

        private void Awake()
        {
            if (worldPont == null)
                worldPont = FindObjectOfType<WorldPontArray>();
        }

        private void Start()
        {
            _randomPoint = Random.Range(0, worldPont.WorldMovementPoints.Length);

            _waitTime = _startWaitTime;
        }

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, worldPont.WorldMovementPoints[_randomPoint].position, _speed * Time.deltaTime);

            FlipWithPoints();

            if (Vector2.Distance(transform.position, worldPont.WorldMovementPoints[_randomPoint].position) < 0.2f)
            {
                if (_waitTime <= 0)
                {
                    _randomPoint = Random.Range(0, worldPont.WorldMovementPoints.Length);

                    _waitTime = _startWaitTime;
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
        }

        private void FlipWithPoints()
        {
            if (worldPont.WorldMovementPoints[_randomPoint].transform.position.x < transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (worldPont.WorldMovementPoints[_randomPoint].transform.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}