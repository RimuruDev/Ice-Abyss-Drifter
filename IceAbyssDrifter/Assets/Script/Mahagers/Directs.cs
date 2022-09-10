using UnityEngine;
using UnityEngine.UI;

public sealed class Directs : MonoBehaviour
{
    [SerializeField] private GameObject  posters;

    [SerializeField] private Text  dirX;
    [SerializeField] private Text  dirY;

    private void Update()
    {
         dirX.text = "X: " +  posters.transform.position.x.ToString();
         dirY.text = "Y: " +  posters.transform.position.y.ToString();
    }
}