using UnityEngine;

namespace RimuruDev.GameFinal
{
    public sealed class EndGameView : MonoBehaviour
    {
        private EndGameModel gameModel = null;

        private void Awake() => gameModel = GetComponent<EndGameModel>();

        public void UpdateUnlockCounterText() =>
            gameModel.unlockCounterText.text = $"{gameModel.unlockTimerCopyForText}";
    }
}