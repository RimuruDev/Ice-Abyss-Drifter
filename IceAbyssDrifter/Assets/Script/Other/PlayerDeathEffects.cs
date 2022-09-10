using RimuruDev.Mechanics.Character;
using UnityEngine;

public sealed class PlayerDeathEffects : MonoBehaviour
{
    [SerializeField] private GameObject  bloodeffect;
    [SerializeField] private Transform  Player;

    private void Update()
    {
        transform.position =  Player.transform.position;

        if (DeadPlayer. isDead == true)
        {
            gameObject.SetActive(true);

            Instantiate( bloodeffect, transform.position, Quaternion.identity);
        }
        else if (DeadPlayer. isDead == false)
        {
            transform.position =  Player.transform.position;
        }
    }
}