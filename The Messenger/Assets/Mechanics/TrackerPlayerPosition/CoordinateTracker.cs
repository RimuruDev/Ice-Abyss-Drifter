using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RimuruDev.Mechanics
{
    public sealed class CoordinateTracker : MonoBehaviour
    {
        [SerializeField] private Text[] characterCoordinates;

        private CharacterController characterController = null;
        private string[] characterCoordinateText = { ":X", ":Y" };

        private void Awake()
        {
            if (characterController == null)
            {
                characterController = GetComponent<CharacterController>();

                if (characterController == null)
                    characterController = GameObject.FindObjectOfType<CharacterController>();
            }

            if (characterCoordinates == null)
                Debug.LogError("CharacterCoordinates is null...");
        }

        private void Update() => RenderCoordinate();

        private void RenderCoordinate()
        {
            characterCoordinates[0].text = $"{(int)characterController.GetCharacterTransform.position.x}{characterCoordinateText[0]}";
            characterCoordinates[1].text = $"{(int)characterController.GetCharacterTransform.position.y}{characterCoordinateText[1]}";
        }
    }
}