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

        private void Update()
        {
            if (endGameModel.unlockTimerCopyForText <= 0)
                endGameModel. DisableTextUnlockCounter(endGameModel.unlockCounterText, out isWhetherToDisplay);


        }

        private void Init()
        {
            endGameView = GetComponent<EndGameView>();
            endGameModel = GetComponent<EndGameModel>();
        }
    }
}