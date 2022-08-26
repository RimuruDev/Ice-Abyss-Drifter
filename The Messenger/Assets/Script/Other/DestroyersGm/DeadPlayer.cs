using RimuruDev.UI;
using UnityEngine;

using static RimuruDev.Helpers.Tag;

namespace RimuruDev.Mechanics.Character
{
    public sealed class DeadPlayer : MonoBehaviour
    {
        public static bool _isDead = false;
        [SerializeField] GameObject _gun;

        private GenerationRandomText generationRandomText = null;

        private void Awake()
        {
            _isDead = false;

            if (generationRandomText == null)
            {
                generationRandomText = GetComponent<GenerationRandomText>();

                if (generationRandomText == null)
                    generationRandomText = GameObject.FindObjectOfType<GenerationRandomText>();
            }
        }

        private void OnTriggerEnter2D(Collider2D _coll)
        {
            if (_coll.gameObject.CompareTag(Enemy) && LutingPlayer._heKeng == false)
            {
                Destroy(gameObject);
                Destroy(_gun);
                _isDead = true;

                generationRandomText.SetAfterDeatText((Random.Range(0, generationRandomText.GetAfterDefeatTextLength)));
            }
        }
    }
}