using System.Collections;
using UnityEngine;

namespace RimuruDev
{
    public sealed class DestructionTimer : MonoBehaviour
    {
        [SerializeField] private DestructionMode destructionMode = DestructionMode.Coroutine;
        [Space]
        [SerializeField] private float timerToDestruction;

        public float TimerToDestruction { get => timerToDestruction; set => timerToDestruction = value; }

        private void Start()
        {
            if (destructionMode == DestructionMode.Coroutine)
                StartCoroutine(nameof(Destruction));
        }

        private void Update()
        {
            if (!(destructionMode == DestructionMode.TimeDeltaTime)) return;

            if (TimerToDestruction <= 0f)
                Destroy(gameObject);

            TimerToDestruction -= Time.deltaTime;
        }

        private IEnumerator Destruction()
        {
            yield return new WaitForSeconds(TimerToDestruction);

            Destroy(gameObject);
        }

        private enum DestructionMode { TimeDeltaTime, Coroutine }
    }
}