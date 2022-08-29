using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class TransformPoint : MonoBehaviour
    {
        [SerializeField] private Transform[] _point;

        public static Transform[] _points;

        private void Awake() => _points = _point;
    }
}