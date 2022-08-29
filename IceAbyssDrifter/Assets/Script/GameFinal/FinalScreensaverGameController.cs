using System.Collections;
using UnityEngine;

namespace RimuruDev.GameFinal
{
    /// <summary>
    /// The controller for the game's ending screensaver.
    /// </summary>
    public sealed class FinalScreensaverGameController : MonoBehaviour
    {
        public FinalScreensaverGameDataContainer dataContainer;
        private FinalScreensaverGameUIHandler uIHandler;
        private bool isWhetherToDisplay = true;

        private void Awake()
        {
            uIHandler = new FinalScreensaverGameUIHandler(dataContainer);

            dataContainer.UnlockTimerCopyForText = dataContainer.UnlockTimer;
        }

        private void Start() => StartCoroutine(nameof(UnlockPanel));

        private void Update()
        {
            if (!isWhetherToDisplay) return;

            if (dataContainer.UnlockTimerCopyForText <= 0)
                uIHandler.DisableUnlockCounterText(dataContainer.UnlockCounterText.gameObject, out isWhetherToDisplay);

            dataContainer.UnlockTimerCopyForText -= Time.deltaTime;

            uIHandler.UpdateUnlockCounterText(dataContainer.UnlockTimerCopyForText);
        }

        private IEnumerator UnlockPanel()
        {
            yield return new WaitForSeconds(dataContainer.UnlockTimer);

            dataContainer.EndGameButton.SetActive(true);
        }
    }
}