using RimuruDev.AI;
using UnityEngine;

namespace RimuruDev.Helpers
{
    public sealed class OnDrawGizmosHelper : MonoBehaviour
    {
        [SerializeField] private bool isVisualization;

        private BeePointArray beePointArray = null;
        private WorldPontArray worldPontArray = null;

        private void Awake() => Init();

        private void OnValidate() => Init();

        private void OnDrawGizmos()
        {
            if (!isVisualization) return;

            VisualizationBeeTargetsPoint(beePointArray.BeeMovementPoints, Color.red);
            VisualizationBeeTargetsPoint(worldPontArray.WorldMovementPoints, Color.blue);
        }

        private void VisualizationBeeTargetsPoint(Transform[] points, Color color)
        {
            var currenpPoint = points[0].position;

            for (var i = 0; i < points.Length; i++)
            {
                Debug.DrawLine(currenpPoint, points[i].position, color);
            }
        }

        private void Init()
        {
            if (beePointArray == null)
                beePointArray = FindObjectOfType<BeePointArray>();

            if (worldPontArray == null)
                worldPontArray = FindObjectOfType<WorldPontArray>();
        }
    }
}