using UnityEngine;

public sealed class SoldManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject  gun;
    [SerializeField] private GameObject  pet;
    [SerializeField] private GameObject  ID;
    [SerializeField] private GameObject  Trecker;

    [Header("BuyButtons")]
    [SerializeField] private GameObject  buySpeed;
    [SerializeField] private GameObject  buyRadiation;
    [SerializeField] private GameObject  buyNormalInventore;
    [SerializeField] private GameObject  buyBigInventore;
    [SerializeField] private GameObject  buyPet;
    [SerializeField] private GameObject  buyGun;
    [SerializeField] private GameObject  buyID;
    [SerializeField] private GameObject  buyTrecker;

    [Header("SoldImage")]
    [SerializeField] private GameObject  soldSpeed;
    [SerializeField] private GameObject  soldRadiation;
    [SerializeField] private GameObject  soldInventoreNormal;
    [SerializeField] private GameObject  soldInventoreBig;
    [SerializeField] private GameObject  soldPet;
    [SerializeField] private GameObject  soldGun;
    [SerializeField] private GameObject  soldID;
    [SerializeField] private GameObject  soldTrecker;

    private void Update()
    {
        if (MagazineWorkest. speedSold == true)
        {
             buySpeed.SetActive(false);
             soldSpeed.SetActive(true);
        }

        if (MagazineWorkest. radiationSold == true)
        {
             buyRadiation.SetActive(false);
             soldRadiation.SetActive(true);
        }

        if (MagazineWorkest. inventoreNormalSold == true)
        {
             buyNormalInventore.SetActive(false);
             soldInventoreNormal.SetActive(true);
        }

        if (MagazineWorkest. inventoreBigSold == true)
        {
             buyBigInventore.SetActive(false);
             soldInventoreBig.SetActive(true);
        }

        if (MagazineWorkest. petSold == true)
        {
             buyPet.SetActive(false);
             soldPet.SetActive(true);
        }

        if (MagazineWorkest. gunSold == true)
        {
             buyGun.SetActive(false);
             soldGun.SetActive(true);
        }

        if (MagazineWorkest. idSold == true)
        {
             buyID.SetActive(false);
             soldID.SetActive(true);
        }

        if (MagazineWorkest. treckerSold == true)
        {
             buyTrecker.SetActive(false);
             soldTrecker.SetActive(true);
        }
    }
}