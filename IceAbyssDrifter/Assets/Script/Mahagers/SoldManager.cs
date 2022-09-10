using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject _pet;
    [SerializeField] GameObject _ID;
    [SerializeField] GameObject _Trecker;

    [Header("BuyButtons")]
    [SerializeField] GameObject _buySpeed;
    [SerializeField] GameObject _buyRadiation;
    [SerializeField] GameObject _buyNormalInventore;
    [SerializeField] GameObject _buyBigInventore;
    [SerializeField] GameObject _buyPet;
    [SerializeField] GameObject _buyGun;
    [SerializeField] GameObject _buyID;
    [SerializeField] GameObject _buyTrecker;

    [Header("SoldImage")]
    [SerializeField] GameObject _soldSpeed;
    [SerializeField] GameObject _soldRadiation;
    [SerializeField] GameObject _soldInventoreNormal;
    [SerializeField] GameObject _soldInventoreBig;
    [SerializeField] GameObject _soldPet;
    [SerializeField] GameObject _soldGun;
    [SerializeField] GameObject _soldID;
    [SerializeField] GameObject _soldTrecker;

    void Update()
    {
        if (MagazineWorkest._speedSold == true)
        {
            _buySpeed.SetActive(false);
            _soldSpeed.SetActive(true);
        }

        if(MagazineWorkest._radiationSold == true)
        {
            _buyRadiation.SetActive(false);
            _soldRadiation.SetActive(true);
        }

        if (MagazineWorkest._inventoreNormalSold == true)
        {
            _buyNormalInventore.SetActive(false);
            _soldInventoreNormal.SetActive(true);
        }

        if(MagazineWorkest._inventoreBigSold == true)
        {
            _buyBigInventore.SetActive(false);
            _soldInventoreBig.SetActive(true);
        }

        if(MagazineWorkest._petSold == true)
        {
            _buyPet.SetActive(false);
            _soldPet.SetActive(true);
        }

        if(MagazineWorkest._gunSold == true)
        {
            _buyGun.SetActive(false);
            _soldGun.SetActive(true);
        }

        if(MagazineWorkest._idSold == true)
        {
            _buyID.SetActive(false);
            _soldID.SetActive(true);
        }

        if (MagazineWorkest._treckerSold == true)
        {
            _buyTrecker.SetActive(false);
            _soldTrecker.SetActive(true);
        }
    }
}
