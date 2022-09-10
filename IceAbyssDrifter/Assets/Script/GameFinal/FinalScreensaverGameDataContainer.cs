using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.GameFinal
{
    /// <summary>
    /// Controller data for the game's final cutscene.
    /// </summary>
    [System.Serializable]
    public sealed class FinalScreensaverGameDataContainer
    {
        [Header("UIHelper")]
        [SerializeField] private Text unlockCounterText;
        [SerializeField] private GameObject endGameButton;
        [Space]
        [Header("Timers")]
        [SerializeField] private float unlockTimer = 15;
        [SerializeField] private float unlockTimerCopyForText;

        public Text UnlockCounterText => unlockCounterText;
        public GameObject EndGameButton => endGameButton;

        public float UnlockTimer => unlockTimer;
        public float UnlockTimerCopyForText { get => unlockTimerCopyForText; set => unlockTimerCopyForText = value; }
    }
}