using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class EnemyAI : MonoBehaviour
    {
        [SerializeField] private float  speed;
        [SerializeField] private float  startWaitTime;
        [SerializeField] private float  minDistance;

        private bool  isAgry = false;
        private float  waitTime;
        private int  randomPoint;

        private AllMobMovementPoints allMobPoints = null;

        private void Awake()
        {
            allMobPoints = FindObjectOfType<AllMobMovementPoints>();
        }

        private void Start()
        {
             randomPoint = Random.Range(0, allMobPoints.AllPoints.Length);

             waitTime =  startWaitTime;
        }

        private void FixedUpdate()
        {
            if ( isAgry == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, allMobPoints.AllPoints[ randomPoint].position,  speed * Time.deltaTime);
               
                FlipWithPoints();
                
                if (Vector2.Distance(transform.position, allMobPoints.AllPoints[ randomPoint].position) < 0.2f)
                {

                    if ( waitTime <= 0)
                    {
                         randomPoint = Random.Range(0, allMobPoints.AllPoints.Length);
                         waitTime =  startWaitTime;
                    }
                    else
                    {
                         waitTime -= Time.deltaTime;
                    }
                }
            }

            if (Vector2.Distance(transform.position, CharacterController. playerPoint.transform.position) <  minDistance && LutingPlayer. heKeng == false)
            {
                 isAgry = true;

                if ( isAgry)
                {
                    transform.position = Vector2.MoveTowards(transform.position, CharacterController. playerPoint.transform.position,  speed * Time.deltaTime);

                    FlipWithPlayer();
                }
            }
            else if (Vector2.Distance(transform.position, CharacterController. playerPoint.transform.position) >  minDistance)
            {
                 isAgry = false;
            }

            if (LutingPlayer. heKeng)
                 minDistance = 0f;
        }

        private void FlipWithPlayer()
        {
            if (CharacterController. playerPoint.transform.position.x < transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (CharacterController. playerPoint.transform.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        private void FlipWithPoints()
        {
            if (allMobPoints.AllPoints[ randomPoint].transform.position.x < transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (allMobPoints.AllPoints[ randomPoint].transform.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}