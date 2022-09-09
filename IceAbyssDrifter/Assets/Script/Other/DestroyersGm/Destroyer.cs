using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Destroyer : MonoBehaviour
{
    [SerializeField] private float  deadTime;

    private void Start() => StartCoroutine(nameof(Dead));

    private IEnumerator Dead()
    {
        yield return new WaitForSeconds( deadTime);

        Destroy(gameObject);
    }
}
