using UnityEngine;

public sealed class DestroyObject : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject  effectUran;
    [SerializeField] private GameObject  effectUgly;
    [SerializeField] private GameObject  effectGold;
    [SerializeField] private GameObject  effectMetal;
    [SerializeField] private GameObject  effectHorny;
    [SerializeField] private GameObject  effectRubin;
    [SerializeField] private GameObject  effectCosmo;

    [Header("Bools")]
    [SerializeField] private bool  isUgly;
    [SerializeField] private bool  isMetal;
    [SerializeField] private bool  isGold;
    [SerializeField] private bool  isUran;
    [SerializeField] private bool  isHorny;
    [SerializeField] private bool  isRubin;
    [SerializeField] private bool  isCosmo;

    private void OnTriggerEnter2D(Collider2D  coll)
    {
        if ( coll.gameObject.CompareTag("Player"))
        {
            if ( isUran == true)
            {
                Instantiate( effectUran, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if ( isUgly == true)
            {
                Instantiate( effectUgly, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if ( isMetal == true)
            {
                Instantiate( effectMetal, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if ( isHorny == true)
            {
                Instantiate( effectHorny, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if ( isGold == true)
            {
                Instantiate( effectGold, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if ( isRubin == true)
            {
                Instantiate( effectRubin, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if ( isCosmo == true)
            {
                Instantiate( effectCosmo, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if ( coll.gameObject.CompareTag("Sold") ||  coll.gameObject.CompareTag("Raport") ||  coll.gameObject.CompareTag("Magas"))
        {
            Destroy(gameObject);
        }
    }
}
