using UnityEngine;

namespace RimuruDev
{
    [RequireComponent(typeof(OreTagProvider))]
    [RequireComponent(typeof(DestructionTimer))]
    public sealed class OreHandler : MonoBehaviour, IOre
    {
        [SerializeField] private string id;

        public string ID { get => id; private set => id = value; }

        public void TookTheOre(string tag, GameDataContainer dataContainer)
        {
            AddOre(tag, dataContainer);
        }

        public void AddOre(string currentEnterOreTag, GameDataContainer dataContainer)
        {
            for (var i = 0; i < dataContainer.oreTagPool.Length; i++)
            {
                if (currentEnterOreTag == ID)//dataContainer.oreTagPool[i])
                {
                    if (GameManager._inventor < GameManager._limitInventore)
                    {
                        //GameManager._pointUgly += 1f;
                        dataContainer.oreDictionary.Add(currentEnterOreTag, 1);
                        dataContainer.audioForOre.Sfx();

                        return;
                    }
                    else if (GameManager._inventor >= GameManager._limitInventore)
                    {
                        GameManager._pointUgly += 0f;
                        dataContainer.audioForOre.Sfx();

                        return;
                    }
                }
            }
        }



#if UNITY_EDITOR
        private void OnValidate()
        {
            if (ID == string.Empty)
                ID = GetComponent<OreTagProvider>().EffectTag;
        }
#endif

    }
}