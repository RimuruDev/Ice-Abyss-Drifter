using UnityEngine;

public sealed class GunTransform : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update() => gameObject.transform.position = _player.transform.position;
}