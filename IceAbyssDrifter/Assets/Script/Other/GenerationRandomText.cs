using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.UI
{
    public sealed class GenerationRandomText : MonoBehaviour
    {
        public Text  randomText;
        [TextArea()] public string[] afterDefeatText;

        public void SetAfterDeatText(int index) =>  randomText.text = $"{afterDefeatText[index]}";

        public int GetAfterDefeatTextLength => afterDefeatText.Length;
    }
}