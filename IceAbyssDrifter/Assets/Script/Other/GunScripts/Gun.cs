using RimuruDev;
using RimuruDev.Mechanics.Character;
using UnityEngine;

public sealed class Gun : MonoBehaviour
{
    private GameDataContainer dataContainer; 

    [SerializeField] private float  offset;
    public static bool  FacingRight;

    [SerializeField] private GameObject  effectShot;

    [SerializeField] private GameObject  bullet;
    [SerializeField] private Transform  shotPos;

    [SerializeField] private AudioSource  shotSound;

    [SerializeField] private float  timeStart;
    private float  timeShot;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    private void Update()
    {
        if (LutingPlayer. isMagazineOpen == false && dataContainer.IsPaused == false)
        {
            if (dataContainer.MetalBullet >= 1f)
            {
                if ( timeShot <= 0f)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Instantiate( bullet,  shotPos.position, transform.rotation);
                        Instantiate( effectShot,  shotPos.transform.position, transform.rotation);
                         shotSound.pitch = Random.Range(0.7f, 1f);
                         shotSound.Play();
                        dataContainer.MetalBullet -= 1f;
                         timeShot =  timeStart;
                    }
                }
                else
                {
                     timeShot -= Time.deltaTime;
                }
            }
        }
        else
        {
             timeShot -= Time.deltaTime;
        }

        if (DeadPlayer. isDead == true)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3  difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float  rotateZ = Mathf.Atan2( difference.y,  difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f,  rotateZ +  offset);

        if ( difference.x > 0 &&  FacingRight)
        {
            Flip();
             offset = 0;
        }
        else if ( difference.x < 0 && ! FacingRight)
        {
            Flip();
             offset = 180f;
        }
    }

    private void Flip()
    {
         FacingRight = ! FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}