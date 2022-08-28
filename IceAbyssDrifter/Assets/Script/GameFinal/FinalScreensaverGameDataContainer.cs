using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.GameFinal.Test
{
    /// <summary>
    /// Controller data for the game's final cutscene.
    /// </summary>
    [System.Serializable]
    public sealed class FinalScreensaverGameDataContainer
    {
        [Header("UI - Texts")]
        public Text unlockCounterText;
        [Space]
        [Header("UI - Buttons")]
        public GameObject endGameButton;
        [Space]
        [Header("Timers for visualizing exit button")]
        public float unlockTimer = 15;
        [HideInInspector] public float unlockTimerCopyForText;
    }
}