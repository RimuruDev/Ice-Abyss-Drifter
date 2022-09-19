using UnityEngine;

namespace RimuruDev
{
    public sealed class OreController : MonoBehaviour
    {
        private GameDataContainer dataContainer = null;

        private void Awake()
        {
            dataContainer = FindObjectOfType<GameDataContainer>();
        }

        public void ApplayPickUpOre(string id)
        {
            switch (id)
            {
                case "SpaceOre":
                   // dataContainer.oreIndex[0]
                    break;
                case "GoldOre":
                    break;
                case "HoneyOre":
                    break;
                case "IronOre":
                    break;
                case "MoonOre":
                    break;
                case "CoalOre":
                    break;
                case "RubyOre":
                    break;
                default:
                    Debug.LogError("Tag error...");
                    break;

            }
        }

        private void OnEnable()
        {
            EventContainer.OnAddOreAction += ApplayPickUpOre;
        }

        private void OnDisable()
        {
            EventContainer.OnAddOreAction -= ApplayPickUpOre;
        }
    }
}