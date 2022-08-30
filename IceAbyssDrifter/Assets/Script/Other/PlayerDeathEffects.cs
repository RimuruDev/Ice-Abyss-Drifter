using RimuruDev.Mechanics.Character;
using UnityEngine;

public sealed class PlayerDeathEffects : MonoBehaviour
{
    [SerializeField] private GameObject _bloodeffect;
    [SerializeField] private Transform _Player;

    private void Update()
    {
        transform.position = _Player.transform.position;

        if (DeadPlayer._isDead == true)
        {
            gameObject.SetActive(true);

            Instantiate(_bloodeffect, transform.position, Quaternion.identity);
        }
        else if (DeadPlayer._isDead == false)
        {
            transform.position = _Player.transform.position;
        }
    }
}