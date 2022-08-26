using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Enemy") || _coll.gameObject.CompareTag("Gary") || _coll.gameObject.CompareTag("Other"))
        {
            Destroy(gameObject);
        }
    }

}
