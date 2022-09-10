using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class MobsWorld : MonoBehaviour
    {
        [SerializeField] private float  speed;
        [SerializeField] private float  startWaitTime;

        private float  waitTime;
        private int  randomPoint;

        private WorldPontArray worldPont;

        private void Awake()
        {
            if (worldPont == null)
                worldPont = FindObjectOfType<WorldPontArray>();
        }

        private void Start()
        {
             randomPoint = Random.Range(0, worldPont.WorldMovementPoints.Length);

             waitTime =  startWaitTime;
        }

        private void FixedUpdate()
        {
            transform.position = Vector2.MoveTowards(transform.position, worldPont.WorldMovementPoints[ randomPoint].position,  speed * Time.deltaTime);

            FlipWithPoints();

            if (Vector2.Distance(transform.position, worldPont.WorldMovementPoints[ randomPoint].position) < 0.2f)
            {
                if ( waitTime <= 0)
                {
                     randomPoint = Random.Range(0, worldPont.WorldMovementPoints.Length);

                     waitTime =  startWaitTime;
                }
                else
                {
                     waitTime -= Time.deltaTime;
                }
            }
        }

        private void FlipWithPoints()
        {
            if (worldPont.WorldMovementPoints[ randomPoint].transform.position.x < transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (worldPont.WorldMovementPoints[ randomPoint].transform.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}