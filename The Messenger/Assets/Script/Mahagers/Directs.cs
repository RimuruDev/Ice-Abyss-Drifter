using UnityEngine;
using UnityEngine.UI;

public class Directs : MonoBehaviour
{
    [SerializeField] GameObject _posters;

    [SerializeField] Text _dirX;
    [SerializeField] Text _dirY;

    void Update()
    {
        _dirX.text = "X: " + _posters.transform.position.x.ToString();
        _dirY.text = "Y: " + _posters.transform.position.y.ToString();
    }
}