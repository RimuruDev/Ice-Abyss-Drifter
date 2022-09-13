using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D _cool)
    {
        if (_cool.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
