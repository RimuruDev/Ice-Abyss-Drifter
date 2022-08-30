using System.Collections;
using UnityEngine;

public sealed class Spawner : MonoBehaviour
{
    [SerializeField] private float _stratTime;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _spawnObject;

    private void Start() => StartCoroutine(nameof(Spawn));

    private void Restart() => StartCoroutine(nameof(Spawn));

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_stratTime);

        Instantiate(_spawnObject, _spawnPoint.transform.position, Quaternion.identity);

        Restart();
    }
}