using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.GameFinal
{
    public sealed class EndGameModel : MonoBehaviour
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

        public IEnumerator UnlockPanel(GameObject panel, float unlockTimer)
        {
            yield return new WaitForSeconds(unlockTimer);

            panel.SetActive(true);
        }

        public void DisableTextUnlockCounter(GameObject textCounter, out bool isWhetherToDisplay)
        {
            textCounter.SetActive(false);

            isWhetherToDisplay = false;
        }
    }
}