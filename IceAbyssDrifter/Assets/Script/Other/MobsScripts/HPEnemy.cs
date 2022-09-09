using RimuruDev;
using UnityEngine;

public sealed class HPEnemy : MonoBehaviour
{
    private GameDataContainer dataContainer;
    [SerializeField] private float  health;
    private float  Nhealth;

    [SerializeField] private bool  isKing = false;
    [SerializeField] private GameObject  cloud;
    [SerializeField] private GameObject  king;
    [SerializeField] private GameObject  flex;

    [SerializeField] private GameObject  effectEnemy;
    [SerializeField] private GameObject  blood;

    [SerializeField] private bool  isBee;
    [SerializeField] private bool  isUlitka;
    [SerializeField] private bool  isSheep;
    [SerializeField] private bool  isBuka;
    [SerializeField] private bool  isCat;
    [SerializeField] private bool  isMohan;
    [SerializeField] private bool  isActivator;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();

         Nhealth =  health;
    }

    private void OnTriggerEnter2D(Collider2D  coll)
    {
        if ( coll.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
         health -= 1f;

        Instantiate( effectEnemy, gameObject.transform.position, Quaternion.identity);

        if ( health <= 0f)
        {
            Destroy(gameObject);
            Instantiate( blood, gameObject.transform.position, Quaternion.identity);

             health =  Nhealth;

            if ( isKing == true)
            {
                Instantiate( flex, gameObject.transform.position, Quaternion.identity);
                Instantiate( cloud, gameObject.transform.position, Quaternion.identity);
            }

            if ( isActivator == true && LutingPlayer. heKeng == false)
            {
                Instantiate( king, gameObject.transform.position, Quaternion.identity);
            }

            if (MagazineWorkest. idSold == true && PostScript. idIsYou == true)
            {
                if ( isBee == true)
                {
                    dataContainer.PointMoney += 50f;
                }

                if ( isUlitka == true)
                {
                    dataContainer.PointMoney += 30f;
                }

                if ( isBuka == true)
                {
                    dataContainer.PointMoney += 20f;
                }

                if ( isSheep == true)
                {
                    dataContainer.PointMoney += 80f;
                }

                if ( isMohan == true)
                {
                    dataContainer.PointMoney += 150f;
                }

                if ( isCat == true)
                {
                    dataContainer.PointMoney += 56f;
                }

                if ( isActivator == true)
                {
                    dataContainer.PointMoney += 300f;
                }

                if ( isKing == true)
                {
                    dataContainer.PointMoney += 200f;
                }
            }
        }
    }
}