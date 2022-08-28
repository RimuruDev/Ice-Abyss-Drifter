using System;
using System.Collections;
using UnityEngine;

namespace RimuruDev.GameFinal
{
    public sealed class UnlockPanelController : MonoBehaviour
    {
        private FinalSceenDataContainer dataContainer;
        private bool isWhetherToDisplay = true;

        private void Awake() => dataContainer = GameObject.FindObjectOfType<FinalSceenDataContainer>();

        private void Start()
        {
            Time.timeScale = 0;

            dataContainer.unlockTimerCopyForText = dataContainer.unlockTimer * 2;

            StartCoroutine(nameof(UnlockPanel));
            StartCoroutine(UnlockPanel(15));
        }

        private void Update()
        {
            if (!isWhetherToDisplay) return;

            if (dataContainer.unlockTimerCopyForText <= 0)
                DisableTextUnlockCounter();

            dataContainer.unlockTimerCopyForText -= Time.deltaTime;
        }

        private IEnumerator UnlockPanel(int i)
        {
            yield return new WaitForSeconds(dataContainer.unlockTimer);

            dataContainer.endGameButton.SetActive(true);
        }

        private void DisableTextUnlockCounter()
        {
            dataContainer.unlockCounterText.gameObject.SetActive(false);

            isWhetherToDisplay = false;
        }
    }
}