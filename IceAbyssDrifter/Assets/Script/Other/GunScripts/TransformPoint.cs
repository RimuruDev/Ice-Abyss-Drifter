using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPoint : MonoBehaviour
{
    [SerializeField] Transform[] _point;

    public static Transform[] _points;

    void Awake()
    {
        _points = _point;
    }
}
