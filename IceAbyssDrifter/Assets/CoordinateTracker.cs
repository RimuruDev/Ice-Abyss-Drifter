using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev
{
    public sealed class CoordinateTracker : MonoBehaviour
    {
        [SerializeField] private Text[] coordinateText;

        private GameDataContainer dataContainer = null;

        private void Awake() => dataContainer = FindObjectOfType<GameDataContainer>();

        private void Update()
        {
            // TODO: EventSystem;
            coordinateText[1].text = $"{Mathf.Round(dataContainer.GetActivePlayer.transform.position.y)}:Y";
            coordinateText[0].text = $"{Mathf.Round(dataContainer.GetActivePlayer.transform.position.x)}:X";
        }
    }
}