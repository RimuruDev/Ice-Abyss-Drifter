using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class WorldPontArrsy : MonoBehaviour
    {
        [SerializeField] private Transform[] worldMovementPoints;

        public Transform[] WorldMovementPoints => worldMovementPoints;
    }
}