using UnityEngine;

public sealed class GerySheet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Gary") && LutingPlayer._heKeng == false)
        {
            dataContainer._uranClear = 0f;
            dataContainer._uran = 0f;
            dataContainer._metal = 0f;
            dataContainer._pointUgly = 0f;
            dataContainer._horny = 0f;
            dataContainer._metalBullet = 0f;
            dataContainer._clearRubin = 0f;
            dataContainer._rubin = 0f;
        }
    }
}