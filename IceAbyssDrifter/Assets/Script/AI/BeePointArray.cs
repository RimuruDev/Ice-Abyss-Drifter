using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class BeePointArray : MonoBehaviour
    {
        [SerializeField] private Transform[] beeMovementPoints;

        public Transform[] BeeMovementPoints => beeMovementPoints;
    }
}