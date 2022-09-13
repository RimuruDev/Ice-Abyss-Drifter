using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class OreDestructionEffectContainer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> oreDestructionEffects;

        public List<GameObject> OreDestructionEffects { get => oreDestructionEffects; set => oreDestructionEffects = value; }
    }
}