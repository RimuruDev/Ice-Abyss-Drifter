using UnityEngine;

namespace RimuruDev
{
    public sealed class DestructionTimerData : MonoBehaviour
    {
        [SerializeField] private float defaultDestructionTimerForAI = 120.0f;
        [SerializeField] private float defaultDestructionTimerForOre = 100.0f;
        [SerializeField] private float defaultDestructionTimerForWindow = 6.5f;
        [SerializeField] private float defaultDestructionTimerForEffects = 45.0f;
        [SerializeField] private float defaultDestructionTimerForOthers = 120.0f; // Нейтральные мобы.

        public float DefaultDestructionTimerForAI { get => defaultDestructionTimerForAI; set => defaultDestructionTimerForAI = value; }
        public float DefaultDestructionTimerForOre { get => defaultDestructionTimerForOre; set => defaultDestructionTimerForOre = value; }
        public float DefaultDestructionTimerForWindow { get => defaultDestructionTimerForWindow; set => defaultDestructionTimerForWindow = value; }
        public float DefaultDestructionTimerForEffects { get => defaultDestructionTimerForEffects; set => defaultDestructionTimerForEffects = value; }
        public float DefaultDestructionTimerForOthers { get => defaultDestructionTimerForOthers; set => defaultDestructionTimerForOthers = value; }
    }
}