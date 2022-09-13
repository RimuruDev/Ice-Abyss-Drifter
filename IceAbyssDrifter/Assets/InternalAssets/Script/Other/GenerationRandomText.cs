using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev
{
    public sealed class GenerationRandomText : MonoBehaviour
    {
        [SerializeField] private TextsFrom textsFrom;
        [SerializeField] private Text randomText;
        [Space]
        [SerializeField] private ArrayTextsFromMivioon textsFromMivioon;
        [SerializeField] private ArrayTextsFromRimuruDev textsFromRimuruDev;

        public void SetAfterDeatText(int index)
        {
            if (textsFrom == TextsFrom.RimuruDev)
                randomText.text = $"{textsFromRimuruDev.TextForLosingPlayer[index]}";

            if (textsFrom == TextsFrom.Mivioon)
                randomText.text = $"{textsFromMivioon.TextForLosingPlayer[index]}";
        }

        public int GetAfterDefeatTextLength
        {
            get
            {
                int length = 0;

                if (textsFrom == TextsFrom.Mivioon)
                    length = textsFromMivioon.TextForLosingPlayer.Length;

                if (textsFrom == TextsFrom.RimuruDev)
                    length = textsFromRimuruDev.TextForLosingPlayer.Length;

                if (length < 0) { Debug.LogError("The size of an array cannot be negative."); length = 0; }

                return length;
            }
        }
    }

    public enum TextsFrom
    {
        RimuruDev,
        Mivioon
    }

    [System.Serializable]
    public sealed class ArrayTextsFromMivioon
    {
        [SerializeField] private string[] textForLosingPlayer;

        public string[] TextForLosingPlayer => textForLosingPlayer;
    }

    [System.Serializable]
    public sealed class ArrayTextsFromRimuruDev
    {
        [SerializeField] private string[] textForLosingPlayer;

        public string[] TextForLosingPlayer => textForLosingPlayer;
    }
}