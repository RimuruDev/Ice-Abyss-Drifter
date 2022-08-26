using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float _deadTime;

    void Start()
    {
        StartCoroutine("Dead");
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(_deadTime);
        Destroy(gameObject);
    }
}
