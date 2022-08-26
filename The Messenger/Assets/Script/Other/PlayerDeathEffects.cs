using RimuruDev.Mechanics.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathEffects : MonoBehaviour
{
    [SerializeField] GameObject _bloodeffect;
    [SerializeField] Transform _Player;

    void Update()
    {
        transform.position = _Player.transform.position;

        if (DeadPlayer._isDead == true)
        {
            gameObject.SetActive(true);
            Instantiate(_bloodeffect, transform.position, Quaternion.identity);
        }
        else if (DeadPlayer._isDead == false)
        {
            transform.position = _Player.transform.position;
        }
    }
}
