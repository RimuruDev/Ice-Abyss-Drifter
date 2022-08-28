using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.GameFinal.Test
{
    /// <summary>
    /// The controller for the game's ending screensaver.
    /// </summary>
    public sealed class EndGameController : MonoBehaviour
    {
        public EndGameDataContainer dataContainer;

        private EndGameUIHandler uIHandler;
        private bool isWhetherToDisplay = true;

        private void Awake()
        {
            uIHandler = new EndGameUIHandler(dataContainer);

            dataContainer.unlockTimerCopyForText = dataContainer.unlockTimer;
        }

        private void Start() => StartCoroutine(nameof(UnlockPanel));

        private void Update()
        {
            if (!isWhetherToDisplay) return;

            if (dataContainer.unlockTimerCopyForText <= 0)
                uIHandler.DisableUnlockCounterText(dataContainer.unlockCounterText.gameObject, out isWhetherToDisplay);

            dataContainer.unlockTimerCopyForText -= Time.deltaTime;

            uIHandler.UpdateUnlockCounterText(dataContainer.unlockTimerCopyForText);
        }

        private IEnumerator UnlockPanel()
        {
            yield return new WaitForSeconds(dataContainer.unlockTimer);

            dataContainer.endGameButton.SetActive(true);
        }
    }

    /// <summary>
    /// Controller data for the game's final cutscene.
    /// </summary>
    [System.Serializable]
    public sealed class EndGameDataContainer
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

    /// <summary>
    /// The UI handler for the game's final cutscene.
    /// </summary>
    [System.Serializable]
    public sealed class EndGameUIHandler
    {
        private readonly EndGameDataContainer dataContainer = null;

        public EndGameUIHandler(EndGameDataContainer dataContainer) =>
            this.dataContainer = dataContainer;

        /// <summary>
        /// Updates the text of the user interface counter. At the end of which, the exit button from the game is unlocked.
        /// </summary>
        /// <param name="timer">The time until the exit button is unlocked.</param>
        public void UpdateUnlockCounterText(float timer) =>
            dataContainer.unlockCounterText.text = $"{(int)timer}";

        /// <summary>
        /// Disable game exit button unlock counter text.
        /// </summary>
        /// <param name="text">The text to turn off because the button is unlocked.</param>
        /// <param name="isWhetherToDisplay">Required for additional verification in the update. *Optimization flag.</param>
        public void DisableUnlockCounterText(GameObject text, out bool isWhetherToDisplay)
        {
            text.SetActive(false);

            isWhetherToDisplay = false;
        }
    }
}