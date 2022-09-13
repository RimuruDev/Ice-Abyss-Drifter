using UnityEngine;

namespace RimuruDev
{
    public sealed class AntiSpawnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Sold") || collision.gameObject.CompareTag("Raport") || collision.gameObject.CompareTag("Magas"))
                Destroy(gameObject);
        }
    }
}