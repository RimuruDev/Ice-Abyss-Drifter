using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _stratTime;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _spawnObject;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    void Restart()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_stratTime);
        Instantiate(_spawnObject, _spawnPoint.transform.position, Quaternion.identity);
        Restart();
    }

}
