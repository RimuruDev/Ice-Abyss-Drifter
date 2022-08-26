using RimuruDev.Mechanics.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobaAI : MonoBehaviour
{
    [SerializeField] float _speed = 8;
    [SerializeField] float _distanceOfPlayer = 2f;
    [SerializeField] float _moneyTime;

    void Start()
    {
        StartCoroutine("_PlusMoney");
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, CharacterController._playerPoint.transform.position, _speed * Time.deltaTime);

        _FlipWithPlayer();

        if (DeadPlayer._isDead == true)
        {
            StopCoroutine("_PlusMoney");
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

    void _FlipWithPlayer()
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

    void Replay()
    {
        StartCoroutine("_PlusMoney");
        if (DeadPlayer._isDead == true)
        {
            StopCoroutine("_PlusMoney");
        }
    }

    IEnumerator _PlusMoney()
    {
        yield return new WaitForSeconds(_moneyTime);
        GameManager._pointMoney += 1f;
        Replay();
    }
}
