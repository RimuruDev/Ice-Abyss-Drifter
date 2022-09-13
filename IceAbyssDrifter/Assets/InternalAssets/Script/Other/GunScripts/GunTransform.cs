using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTransform : MonoBehaviour
{
    [SerializeField] Transform _player;

    void Update()
    {
        gameObject.transform.position = _player.transform.position;
    }
}
