using UnityEngine;

namespace RimuruDev
{
    public sealed class BeePointArray : MonoBehaviour
    {
        [SerializeField] private Transform[] beeMovementPoints;

        public Transform[] BeeMovementPoints => beeMovementPoints;
    }
}