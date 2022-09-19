using System;
using UnityEngine;

namespace RimuruDev
{
    public sealed class InteractionWithOres : MonoBehaviour
    {
        private GameDataContainer dataContainer = null;
        private OreDestructionEffectContainer effectContainer = null;

        private void Awake()
        {
            dataContainer = FindObjectOfType<GameDataContainer>();
            effectContainer = FindObjectOfType<OreDestructionEffectContainer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.GetComponent<OreHandler>()) return;
            //if (collision.gameObject.GetComponent<IOre>() == null) return;

            var oreHandler = collision.gameObject.GetComponent<OreHandler>();
            string oreTag = oreHandler.GetComponent<OreTagProvider>().EffectTag;

            FindOreEffectInstantiate(oreTag + "Effect", collision);

            // Calculate and Update Ore in Game
            {
                oreHandler.TookTheOre(oreTag,dataContainer);
            }

            Destroy(collision.gameObject);
        }

        // Coll event
        //private void NotifyAboutExtractionOre(string oreTag)
        //{
        //    EventContainer.SendAboutExtractionOre(oreTag);
        //}

        private void FindOreEffectInstantiate(string oreTag, Collider2D collision)
        {
            foreach (GameObject effect in effectContainer.OreDestructionEffects)
            {
                if (effect.name == oreTag)
                    Instantiate(effect, collision.transform.position, Quaternion.identity);
            }
        }
    }
}