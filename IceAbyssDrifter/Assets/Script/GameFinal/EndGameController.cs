using UnityEngine;

namespace RimuruDev.GameFinal
{
    [RequireComponent(typeof(EndGameView))]
    [RequireComponent(typeof(EndGameModel))]
    public sealed class EndGameController : MonoBehaviour
    {
        private EndGameView endGameView = null;
        private EndGameModel endGameModel = null;
        private bool isWhetherToDisplay = true;

        private void Awake() => Init();

        private void Start() => endGameModel.StartCoroutine(endGameModel.UnlockPanel(endGameModel.endGameButton, endGameModel.unlockTimer));

        private void Update()
        {
            if (!isWhetherToDisplay) return;

            if (endGameModel.unlockTimerCopyForText <= 0)
                endGameModel.DisableTextUnlockCounter(endGameModel.unlockCounterText.gameObject, out isWhetherToDisplay);

            endGameModel.unlockTimerCopyForText -= Time.deltaTime;

            endGameView.UpdateUnlockCounterText();
        }

        private void Init()
        {
            endGameView = GetComponent<EndGameView>();
            endGameModel = GetComponent<EndGameModel>();

            endGameModel.unlockTimerCopyForText = endGameModel.unlockTimer;
        }
    }
}