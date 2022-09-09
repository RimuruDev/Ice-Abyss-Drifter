using RimuruDev.Mechanics.Character;
using System.Collections;
using UnityEngine;

public sealed class HobaAI : MonoBehaviour
{
    [SerializeField] private float _speed = 8;
    [SerializeField] private float _distanceOfPlayer = 2f;
    [SerializeField] private float _moneyTime;

    private void Start() => StartCoroutine(nameof(PlusMoney));

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, CharacterController._playerPoint.transform.position, _speed * Time.deltaTime);

        FlipWithPlayer();

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine(nameof(PlusMoney));
        }

        if (Vector2.Distance(transform.position, CharacterController._playerPoint.transform.position) < _distanceOfPlayer)
        {
            _speed = 0f;
        }
        else if (Vector2.Distance(transform.position, CharacterController._playerPoint.transform.position) > _distanceOfPlayer)
        {
            _speed = 6.5f;
        }
    }

    private void FlipWithPlayer()
    {
        if (CharacterController._playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (CharacterController._playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Replay()
    {
        StartCoroutine(nameof(PlusMoney));

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine(nameof(PlusMoney));
        }
    }

    private IEnumerator PlusMoney()
    {
        yield return new WaitForSeconds(_moneyTime);

        dataContainer._pointMoney += 1f;

        Replay();
    }
}