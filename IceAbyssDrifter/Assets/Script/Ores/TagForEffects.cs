using UnityEngine;

namespace RimuruDev
{
    public sealed class TagForEffects : MonoBehaviour
    {
        [SerializeField] private string effectTag;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (effectTag == string.Empty)
                effectTag = gameObject.name;
        }
#endif

        public string EffectTag { get => effectTag; set => effectTag = value; }
    }
}