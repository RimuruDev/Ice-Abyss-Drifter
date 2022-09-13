using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandpmSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] _obj;

    [SerializeField] float _stratTime;
    [SerializeField] Transform _spawnPoint;

    private int _random;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_stratTime);
        _random = Random.Range(0, _obj.Length);
        Instantiate(_obj[_random], _spawnPoint.transform.position, Quaternion.identity);
        StartCoroutine("Spawn");
    }
}
