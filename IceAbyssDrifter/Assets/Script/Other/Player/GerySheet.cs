using UnityEngine;

public sealed class GerySheet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Gary") && LutingPlayer._heKeng == false)
        {
            GameManager._uranClear = 0f;
            GameManager._uran = 0f;
            GameManager._metal = 0f;
            GameManager._pointUgly = 0f;
            GameManager._horny = 0f;
            GameManager._metalBullet = 0f;
            GameManager._clearRubin = 0f;
            GameManager._rubin = 0f;
        }
    }
}