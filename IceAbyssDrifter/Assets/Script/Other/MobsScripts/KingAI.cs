using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAI : MonoBehaviour
{
    [SerializeField] float _speed;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerControl._playerPoint.transform.position, _speed * Time.deltaTime);

        _FlipWithPlayer();
    }

    void _FlipWithPlayer()
    {
        if (PlayerControl._playerPoint.transform.position.x < transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (PlayerControl._playerPoint.transform.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
