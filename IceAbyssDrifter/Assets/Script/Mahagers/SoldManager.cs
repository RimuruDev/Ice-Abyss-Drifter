using UnityEngine;

public sealed class SoldManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject _gun;
    [SerializeField] private GameObject _pet;
    [SerializeField] private GameObject _ID;
    [SerializeField] private GameObject _Trecker;

    [Header("BuyButtons")]
    [SerializeField] private GameObject _buySpeed;
    [SerializeField] private GameObject _buyRadiation;
    [SerializeField] private GameObject _buyNormalInventore;
    [SerializeField] private GameObject _buyBigInventore;
    [SerializeField] private GameObject _buyPet;
    [SerializeField] private GameObject _buyGun;
    [SerializeField] private GameObject _buyID;
    [SerializeField] private GameObject _buyTrecker;

    [Header("SoldImage")]
    [SerializeField] private GameObject _soldSpeed;
    [SerializeField] private GameObject _soldRadiation;
    [SerializeField] private GameObject _soldInventoreNormal;
    [SerializeField] private GameObject _soldInventoreBig;
    [SerializeField] private GameObject _soldPet;
    [SerializeField] private GameObject _soldGun;
    [SerializeField] private GameObject _soldID;
    [SerializeField] private GameObject _soldTrecker;

    private void Update()
    {
        if (MagazineWorkest._speedSold == true)
        {
            _buySpeed.SetActive(false);
            _soldSpeed.SetActive(true);
        }

        if (MagazineWorkest._radiationSold == true)
        {
            _buyRadiation.SetActive(false);
            _soldRadiation.SetActive(true);
        }

        if (MagazineWorkest._inventoreNormalSold == true)
        {
            _buyNormalInventore.SetActive(false);
            _soldInventoreNormal.SetActive(true);
        }

        if (MagazineWorkest._inventoreBigSold == true)
        {
            _buyBigInventore.SetActive(false);
            _soldInventoreBig.SetActive(true);
        }

        if (MagazineWorkest._petSold == true)
        {
            _buyPet.SetActive(false);
            _soldPet.SetActive(true);
        }

        if (MagazineWorkest._gunSold == true)
        {
            _buyGun.SetActive(false);
            _soldGun.SetActive(true);
        }

        if (MagazineWorkest._idSold == true)
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