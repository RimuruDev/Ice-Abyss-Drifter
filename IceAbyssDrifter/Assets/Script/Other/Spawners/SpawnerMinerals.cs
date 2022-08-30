using System.Collections;
using UnityEngine;

public sealed class SpawnerMinerals : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _timer;
    [SerializeField] private GameObject _spawnObj;

    [Header("SpawnPosX")]
    [SerializeField] private float _xOne;
    [SerializeField] private float _xTwo;

    [Header("SpawnPosY")]
    [SerializeField] private float _yOne;
    [SerializeField] private float _yTwo;

    private void Start() => StartCoroutine(nameof(Spawn));

    private void Restart() => StartCoroutine(nameof(Spawn));

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_timer);

        gameObject.transform.position = new Vector2(Random.Range(_xOne, _xTwo), Random.Range(_yOne, _yTwo));

        Instantiate(_spawnObj, gameObject.transform.position, Quaternion.identity);

        Restart();
    }
}