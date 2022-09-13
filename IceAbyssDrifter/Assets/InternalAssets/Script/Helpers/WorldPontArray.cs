using UnityEngine;

namespace RimuruDev
{
    public sealed class WorldPontArray : MonoBehaviour
    {
        [SerializeField] private Transform[] worldMovementPoints;

        public Transform[] WorldMovementPoints => worldMovementPoints;
    }
}