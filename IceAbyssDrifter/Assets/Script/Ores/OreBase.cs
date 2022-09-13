using UnityEngine;

namespace RimuruDev
{
    [RequireComponent(typeof(DestructionTimer))]
    public sealed class OreBase : MonoBehaviour
    {
#if UNITY_EDITOR
        //private void OnValidate()
        //{
        //    if (GetComponent<DestructionTimer>().TimerToDestruction == 0)
        //        GetComponent<DestructionTimer>().TimerToDestruction = FindObjectOfType<DestructionTimerData>().DefaultDestructionTimerForOre;
        //}
#endif
    }
}