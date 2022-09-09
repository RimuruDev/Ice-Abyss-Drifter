using UnityEngine;

public sealed class GunTransform : MonoBehaviour
{
    [SerializeField] private Transform  player;

    private void Update() => gameObject.transform.position =  player.transform.position;
}