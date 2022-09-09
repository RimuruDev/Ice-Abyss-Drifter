using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class TransformPoint : MonoBehaviour
    {
        [SerializeField] private Transform[]  point;

        public static Transform[]  points;

        private void Awake() =>  points =  point;
    }
}