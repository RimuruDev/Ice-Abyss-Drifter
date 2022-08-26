using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscript : MonoBehaviour
{
    [SerializeField] GameObject _buttonExit;

    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine("End");
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(15);
        _buttonExit.SetActive(true);
    }
}
