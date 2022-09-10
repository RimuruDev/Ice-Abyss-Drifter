using RimuruDev;
using UnityEngine;

public sealed class PostScript : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private GameObject  gun;

    [SerializeField] private GameObject  petHappy;
    [SerializeField] private GameObject  petNormal;
    [SerializeField] private GameObject  petSad;

    [SerializeField] private GameObject  ID;

    [SerializeField] private AudioSource  sound;

    [Header("Bools")]
    [SerializeField] private bool  isSpeed;
    [SerializeField] private bool  isRadiation;
    [SerializeField] private bool  isNormalInventore;
    [SerializeField] private bool  isBigInventore;
    [SerializeField] private bool  isPet;
    [SerializeField] private bool  isGun;
    [SerializeField] private bool  isID;
    [SerializeField] private bool  isTrecker;

    public static bool  isSpeedy;

    public static bool  idIsYou = false;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    private void Start()
    {
        transform.position = new Vector2(Random.Range(-110, 110), Random.Range(10, 70));
         isSpeedy = false;
    }

    private void OnTriggerEnter2D(Collider2D  coll)
    {
        if ( coll.gameObject.CompareTag("Player"))
        {
            if ( isSpeed == true && MagazineWorkest. speedSold == true)
            {
                CharacterController. speed = 9f;
                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();
                Destroy(gameObject);
            }

            if ( isRadiation == true && MagazineWorkest. radiationSold == true)
            {
                dataContainer.UranNormalRadiation = 150f;
                dataContainer.UranRadiation = 150f;

                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();

                Destroy(gameObject);
            }

            if ( isNormalInventore == true && MagazineWorkest. inventoreNormalSold == true)
            {
                dataContainer.LimitInventore += 15f;
                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();
                Destroy(gameObject);
            }

            if ( isBigInventore == true && MagazineWorkest. inventoreBigSold == true)
            {
                dataContainer.LimitInventore += 25f;

                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();

                Destroy(gameObject);
            }

            if ( isGun == true && MagazineWorkest. gunSold == true)
            {
                 gun.SetActive(true);

                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();

                Destroy(gameObject);
            }

            if ( isPet == true && MagazineWorkest. petSold == true)
            {
                float  randomPet = Random.Range(1, 4);

                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();

                switch ( randomPet)
                {
                    case 1:
                        Instantiate( petSad, gameObject.transform.position, Quaternion.identity);
                        break;

                    case 2:
                        Instantiate( petNormal, gameObject.transform.position, Quaternion.identity);
                        break;

                    case 3:
                        Instantiate( petHappy, gameObject.transform.position, Quaternion.identity);
                        break;
                }
                Destroy(gameObject);
            }

            if ( isID == true && MagazineWorkest. idSold == true)
            {
                 ID.SetActive(true);

                 idIsYou = true;

                 sound.pitch = Random.Range(0.8f, 1f);
                 sound.Play();

                Destroy(gameObject);
            }
        }
    }
}