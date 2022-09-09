using RimuruDev.Mechanics.Character;
using System.Collections;
using UnityEngine;
using RimuruDev;

public sealed class HobaAI : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private float  speed = 8;
    [SerializeField] private float  distanceOfPlayer = 2f;
    [SerializeField] private float  moneyTime;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    private void Start() => StartCoroutine(nameof(PlusMoney));

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, CharacterController. playerPoint.transform.position,  speed * Time.deltaTime);

        FlipWithPlayer();

        if (DeadPlayer. isDead == true)
        {
            StopCoroutine(nameof(PlusMoney));
        }

        if (Vector2.Distance(transform.position, CharacterController. playerPoint.transform.position) <  distanceOfPlayer)
        {
             speed = 0f;
        }
        else if (Vector2.Distance(transform.position, CharacterController. playerPoint.transform.position) >  distanceOfPlayer)
        {
             speed = 6.5f;
        }
    }

    private void FlipWithPlayer()
    {
        if (CharacterController. playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (CharacterController. playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Replay()
    {
        StartCoroutine(nameof(PlusMoney));

        if (DeadPlayer. isDead == true)
        {
            StopCoroutine(nameof(PlusMoney));
        }
    }

    private IEnumerator PlusMoney()
    {
        yield return new WaitForSeconds( moneyTime);

        dataContainer.PointMoney += 1f;

        Replay();
    }
}