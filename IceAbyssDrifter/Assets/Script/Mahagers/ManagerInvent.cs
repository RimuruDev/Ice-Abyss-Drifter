using RimuruDev;
using RimuruDev.Mechanics.Character;
using UnityEngine;

public sealed class ManagerInvent : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private GameObject  inventore;

    private bool  isOpenInventore = false;

    public static bool  inventorOpen;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();

         isOpenInventore = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && DeadPlayer. isDead == false && LutingPlayer. isMagazineOpen == false && dataContainer.IsPaused == false)
        {
             isOpenInventore = true;
             inventorOpen = true;

            Time.timeScale = 0;
        }

        if (Input.GetKeyUp(KeyCode.E) && DeadPlayer. isDead == false && LutingPlayer. isMagazineOpen == false && dataContainer.IsPaused == false)
        {
             isOpenInventore = false;
             inventorOpen = false;

            Time.timeScale = 1;
        }

        if ( isOpenInventore == true && DeadPlayer. isDead == false && LutingPlayer. isMagazineOpen == false && dataContainer.IsPaused == false)
        {
             inventore.SetActive(true);
        }
        else if ( isOpenInventore == false)
        {
             inventore.SetActive(false);
        }
    }
}