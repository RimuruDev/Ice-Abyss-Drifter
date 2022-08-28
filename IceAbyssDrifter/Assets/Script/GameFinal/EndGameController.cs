﻿using System.Collections;
using UnityEngine;

namespace RimuruDev.GameFinal.Test
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
}