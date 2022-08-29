using UnityEngine;

public class TransformPoint : MonoBehaviour
{
    [SerializeField] private Transform[] beeMovementPoints;

    [SerializeField] Transform[] _point;

    public static Transform[] _points;

    public Transform[] BeeMovementPoints => beeMovementPoints;

    void Awake()
    {
        _points = _point;
    }
}