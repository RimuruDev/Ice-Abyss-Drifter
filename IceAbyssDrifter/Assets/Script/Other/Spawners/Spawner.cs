using System.Collections;
using UnityEngine;

public sealed class Spawner : MonoBehaviour
{
    [SerializeField] private float  stratTime;
    [SerializeField] private Transform  spawnPoint;
    [SerializeField] private GameObject  spawnObject;

    private void Start() => StartCoroutine(nameof(Spawn));

    private void Restart() => StartCoroutine(nameof(Spawn));

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds( stratTime);

        Instantiate( spawnObject,  spawnPoint.transform.position, Quaternion.identity);

        Restart();
    }
}