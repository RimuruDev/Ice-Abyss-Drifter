using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInvent : MonoBehaviour
{
    [SerializeField] GameObject _inventore;

    private bool _isOpenInventore = false;

    public static bool _inventorOpen;

    void Awake()
    {
        _isOpenInventore = false;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        //{
        //    _isOpenInventore = true;
        //    _inventorOpen = true;
        //    Time.timeScale = 0;       
        //}

        //if (Input.GetKeyUp(KeyCode.E) && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        //{
        //    _isOpenInventore = false;
        //    _inventorOpen = false;
        //    Time.timeScale = 1;
        //}

        //if (_isOpenInventore == true && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        //{
        //    _inventore.SetActive(true);
        //}
        //else if (_isOpenInventore == false)
        //{
        //    _inventore.SetActive(false);
        //}
    }

    public void TestOpenInvent()
    {
        Debug.Log("Test");
        if (DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        {
            _isOpenInventore = true;
            _inventorOpen = true;
            Time.timeScale = 0;
        }

        if (DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        {
            _isOpenInventore = false;
            _inventorOpen = false;
            Time.timeScale = 1;
        }

        if (_isOpenInventore == true && DeadPlayer._isDead == false && LutingPlayer._isMagazineOpen == false && GameManager._isPaused == false)
        {
            _inventore.SetActive(true);
        }
        else if (_isOpenInventore == false)
        {
            _inventore.SetActive(false);
        }
    }
}
