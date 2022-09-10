using RimuruDev.UI;
using UnityEngine;

using static RimuruDev.Helpers.Tag;

namespace RimuruDev.Mechanics.Character
{
    public sealed class DeadPlayer : MonoBehaviour
    {
        public static bool  isDead = false;
        [SerializeField] GameObject  gun;

        private GenerationRandomText generationRandomText = null;

        private void Awake()
        {
             isDead = false;

            if (generationRandomText == null)
            {
                generationRandomText = GetComponent<GenerationRandomText>();

                if (generationRandomText == null)
                    generationRandomText = GameObject.FindObjectOfType<GenerationRandomText>();
            }
        }

        private void OnTriggerEnter2D(Collider2D  coll)
        {
            if ( coll.gameObject.CompareTag(Enemy) && LutingPlayer. heKeng == false)
            {
                Destroy(gameObject);
                Destroy( gun);
                 isDead = true;

                generationRandomText.SetAfterDeatText((Random.Range(0, generationRandomText.GetAfterDefeatTextLength)));
            }
        }
    }
}