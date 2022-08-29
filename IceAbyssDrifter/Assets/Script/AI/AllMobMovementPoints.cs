using UnityEngine;

namespace RimuruDev.AI
{
    public sealed class AllMobMovementPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] allPoints;

        public Transform[] AllPoints { get => allPoints; set => allPoints = value; }
    }
}