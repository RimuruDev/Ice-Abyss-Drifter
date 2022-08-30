using UnityEngine;

public sealed class Dead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _cool)
    {
        if (_cool.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}