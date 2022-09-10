using System.Collections;
using UnityEngine;

public sealed class SpawnerMinerals : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float  timer;
    [SerializeField] private GameObject  spawnObj;

    [Header("SpawnPosX")]
    [SerializeField] private float  xOne;
    [SerializeField] private float  xTwo;

    [Header("SpawnPosY")]
    [SerializeField] private float  yOne;
    [SerializeField] private float  yTwo;

    private void Start() => StartCoroutine(nameof(Spawn));

    private void Restart() => StartCoroutine(nameof(Spawn));

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds( timer);

        gameObject.transform.position = new Vector2(Random.Range( xOne,  xTwo), Random.Range( yOne,  yTwo));

        Instantiate( spawnObj, gameObject.transform.position, Quaternion.identity);

        Restart();
    }
}