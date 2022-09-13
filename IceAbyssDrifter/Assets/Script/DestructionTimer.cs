using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

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
            else
                return;
        }

        private void Update()
        {
            if (!(destructionMode == DestructionMode.TimeDeltaTime)) return;

            if (TimerToDestruction <= 0f)
                Destroy(gameObject);

            TimerToDestruction -= Time.deltaTime;
        }

#if UNITY_EDITOR // Only for editor
        private void OnValidate()
        {
            //if (TimerToDestruction <= 0)
            //   TimerToDestruction = GetComponent<Destroyer>().DeadTime;

            //if (TimerToDestruction <= 0 && gameObject.CompareTag("Enemy"))
            //    TimerToDestruction = FindObjectOfType<DestructionTimerData>().DefaultDestructionTimerForAI;
            //else if (TimerToDestruction <= 0 && gameObject.CompareTag("Other") && gameObject.name != "CustFakes")
            //    TimerToDestruction = FindObjectOfType<DestructionTimerData>().DefaultDestructionTimerForOthers;
            //else if (gameObject.name == "CustFake")
            //    TimerToDestruction = 40;

            //if (gameObject.name == "PushBuild")
            //    TimerToDestruction = 9.9f;

            //// Autho Find value for effects
            //if (TimerToDestruction <= 0 && GetComponent<SortingGroup>() && GetComponent<ParticleSystem>())
            //    TimerToDestruction = 0.5f;

            //if ((gameObject.name == "PushTeleport" ||
            //    gameObject.name == "PushTeleportLive" ||
            //    gameObject.name == "PushMoonTeleport") && gameObject.name != "PushBuild")
            //    TimerToDestruction = 8.0f;

            //if (gameObject.name == "Bullet") TimerToDestruction = 3.0f;
        }
#endif
        private IEnumerator Destruction()
        {
            yield return new WaitForSeconds(TimerToDestruction);

            Destroy(gameObject);
        }

        public enum DestructionMode { TimeDeltaTime, Coroutine }
    }
}