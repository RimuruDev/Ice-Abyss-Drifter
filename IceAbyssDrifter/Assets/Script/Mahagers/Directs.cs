using UnityEngine;
using UnityEngine.UI;

public sealed class Directs : MonoBehaviour
{
    [SerializeField] private GameObject _posters;

    [SerializeField] private Text _dirX;
    [SerializeField] private Text _dirY;

    private void Update()
    {
        _dirX.text = "X: " + _posters.transform.position.x.ToString();
        _dirY.text = "Y: " + _posters.transform.position.y.ToString();
    }
}