using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.GameFinal
{
    public sealed class FinalSceenDataContainer : MonoBehaviour
    {
        [Header("UI - Texts")]
        public Text unlockCounterText;
        [Space]
        [Header("UI - Buttons")]
        public GameObject endGameButton;
        [Space]
        [Header("Timers for visualizing exit button")]
        public float unlockTimer = 15;
        public float unlockTimerCopyForText;
    }
}