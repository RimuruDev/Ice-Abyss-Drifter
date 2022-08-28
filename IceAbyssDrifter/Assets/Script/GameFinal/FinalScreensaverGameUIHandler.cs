using UnityEngine;

namespace RimuruDev.GameFinal.Test
{
    /// <summary>
    /// The UI handler for the game's final cutscene.
    /// </summary>
    [System.Serializable]
    public sealed class FinalScreensaverGameUIHandler
    {
        private readonly FinalScreensaverGameDataContainer dataContainer = null;

        public FinalScreensaverGameUIHandler(FinalScreensaverGameDataContainer dataContainer) =>
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