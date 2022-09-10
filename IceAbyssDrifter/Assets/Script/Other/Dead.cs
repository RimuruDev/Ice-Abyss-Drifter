using UnityEngine;

public sealed class Dead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D  cool)
    {
        if ( cool.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}