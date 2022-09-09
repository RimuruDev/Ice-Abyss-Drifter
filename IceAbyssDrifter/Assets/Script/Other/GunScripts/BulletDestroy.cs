using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BulletDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D  coll)
    {
        if ( coll.gameObject.CompareTag("Enemy") ||  coll.gameObject.CompareTag("Gary") ||  coll.gameObject.CompareTag("Other"))
        {
            Destroy(gameObject);
        }
    }

}