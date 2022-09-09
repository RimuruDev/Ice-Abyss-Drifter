using RimuruDev;
using UnityEngine;

public sealed class GerySheet : MonoBehaviour
{
    private GameDataContainer dataContainer;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();
    }

    private void OnTriggerEnter2D(Collider2D  coll)
    {
        if ( coll.gameObject.CompareTag("Gary") && LutingPlayer. heKeng == false)
        {
            dataContainer.UranClear = 0f;
            dataContainer.Uran = 0f;
            dataContainer.Metal = 0f;
            dataContainer.PointUgly = 0f;
            dataContainer.Horny = 0f;
            dataContainer.MetalBullet = 0f;
            dataContainer.ClearRubin = 0f;
            dataContainer.Rubin = 0f;
        }
    }
}