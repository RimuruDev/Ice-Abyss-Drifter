using UnityEngine;

namespace RimuruDev
{
    public sealed class InteractionWithOres : MonoBehaviour
    {
        private OreDestructionEffectContainer effectContainer;

        private void Awake() => effectContainer = FindObjectOfType<OreDestructionEffectContainer>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.GetComponent<OreBase>()) return;

            FindOreEffectInstantiate(collision);

            Destroy(collision.gameObject);
        }

        private void FindOreEffectInstantiate(Collider2D collision)
        {
            string oreTag = collision.gameObject.GetComponent<TagForEffects>().EffectTag + "Effect";

            foreach (GameObject effect in effectContainer.OreDestructionEffects)
            {
                if (effect.name == oreTag)
                    Instantiate(effect, collision.transform.position, Quaternion.identity);
            }
        }
    }
}