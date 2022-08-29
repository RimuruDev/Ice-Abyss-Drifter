using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class WorldPontArray : MonoBehaviour
    {
        [SerializeField] private Transform[] worldMovementPoints;

        public Transform[] WorldMovementPoints => worldMovementPoints;
    }
}