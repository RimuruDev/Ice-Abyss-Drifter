using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class BeeAI : MonoBehaviour
    {
        private GameDataContainer dataContainer;

        [SerializeField] private BeePointArray beeTransformPoints;

        [SerializeField] float  speed;
        [SerializeField] float  startWaitTime;
        [SerializeField] float  minDistance;

        [SerializeField] bool  isBee;

        private bool  isAgry = false;
        private float  waitTime;
        private int  randomPoint;

        private void Awake()
        {
            dataContainer = FindObjectOfType<GameDataContainer>();

            if (beeTransformPoints == null)
                beeTransformPoints = FindObjectOfType<BeePointArray>();
        }

        private void Start()
        {
             randomPoint = Random.Range(0, beeTransformPoints.BeeMovementPoints.Length);

             waitTime =  startWaitTime;
        }

        private void FixedUpdate()
        {
            if ( isAgry == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, beeTransformPoints.BeeMovementPoints[ randomPoint].position,  speed * Time.deltaTime);

                FlipWithPoints();

                if (Vector2.Distance(transform.position, beeTransformPoints.BeeMovementPoints[ randomPoint].position) < 0.2f)
                {

                    if ( waitTime <= 0)
                    {
                         randomPoint = Random.Range(0, beeTransformPoints.BeeMovementPoints.Length);
                         waitTime =  startWaitTime;
                    }
                    else
                    {
                         waitTime -= Time.deltaTime;
                    }
                }
            }

            if (Vector2.Distance(transform.position, CharacterController. playerPoint.transform.position) <  minDistance)
            {
                 isAgry = true;

                if ( isAgry == true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, CharacterController. playerPoint.transform.position,  speed * Time.deltaTime);
                    FlipWithPlayer();
                }
            }
            else if (Vector2.Distance(transform.position, CharacterController. playerPoint.transform.position) >  minDistance)
            {
                 isAgry = false;
            }

            if (LutingPlayer. heKeng == true)
            {
                 minDistance = 0f;
            }

            if ( isBee == true && LutingPlayer. heKeng == false)
            {
                if (dataContainer.Horny <= 0f)
                {
                     minDistance = 0f;
                }
                else if (dataContainer.Horny >= 1f)
                {
                     minDistance = 5f;
                }
            }
            else if ( isBee == false && LutingPlayer. heKeng == false)
            {
                if (dataContainer.Metal >= 1f || dataContainer.Uran >= 1f || dataContainer.Horny >= 1f || dataContainer.PointUgly >= 1f || dataContainer.UranClear >= 1f || dataContainer.PorohPoint >= 1f || dataContainer.MetalBullet >= 1f || dataContainer.ClearRubin >= 1f || dataContainer.Rubin >= 1f)
                {
                     minDistance = 7f;
                }
                else if (dataContainer.Metal <= 0f && dataContainer.Uran <= 0f && dataContainer.Horny <= 0f && dataContainer.PointUgly <= 0f && dataContainer.UranClear <= 0f && dataContainer.PorohPoint <= 0f && dataContainer.MetalBullet <= 0f && dataContainer.Rubin <= 0f && dataContainer.ClearRubin <= 0f)
                {
                     minDistance = 0f;
                }
            }
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
            if (beeTransformPoints.BeeMovementPoints[ randomPoint].transform.position.x < transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (beeTransformPoints.BeeMovementPoints[ randomPoint].transform.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}