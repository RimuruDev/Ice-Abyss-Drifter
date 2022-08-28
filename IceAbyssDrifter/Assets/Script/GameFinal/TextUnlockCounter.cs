using UnityEngine;

namespace RimuruDev.GameFinal
{
    public sealed class TextUnlockCounter : MonoBehaviour
    {
        private FinalSceenDataContainer dataContainer;

        private void Awake() => dataContainer = GameObject.FindObjectOfType<FinalSceenDataContainer>();

        private void Update()
        {
            if (dataContainer.unlockTimerCopyForText <= 0) return;

            dataContainer.unlockCounterText.text = $"{(int)dataContainer.unlockTimerCopyForText}";
        }
    }
}