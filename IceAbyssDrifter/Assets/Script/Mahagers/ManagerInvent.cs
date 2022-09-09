using RimuruDev;
using RimuruDev.Mechanics.Character;
using UnityEngine;

public sealed class ManagerInvent : MonoBehaviour
{
    private GameDataContainer dataContainer;

    [SerializeField] private GameObject _inventore;

    private bool _isOpenInventore = false;

    public static bool _inventorOpen;

    private void Awake()
    {
        dataContainer = FindObjectOfType<GameDataContainer>();

        _isOpenInventore = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && dataContainer.IsPaused == false)
        {
            _isOpenInventore = true;
            _inventorOpen = true;

            Time.timeScale = 0;
        }

        if (Input.GetKeyUp(KeyCode.E) && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && dataContainer.IsPaused == false)
        {
            _isOpenInventore = false;
            _inventorOpen = false;

            Time.timeScale = 1;
        }

        if (_isOpenInventore == true && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && dataContainer.IsPaused == false)
        {
            _inventore.SetActive(true);
        }
        else if (_isOpenInventore == false)
        {
            _inventore.SetActive(false);
        }
    }
}