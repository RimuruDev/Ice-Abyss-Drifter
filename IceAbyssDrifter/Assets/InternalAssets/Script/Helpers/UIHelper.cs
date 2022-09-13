using UnityEngine;

namespace RimuruDev.Helpers
{
    public sealed class UIHelper : MonoBehaviour
    {
        [SerializeField] private ManagerInvent managerInvent;

        private void Awake()
        {
            managerInvent = FindObjectOfType<ManagerInvent>();
        }

        public void OpenAndCloseWindow(GameObject window) => window.SetActive(!window.activeInHierarchy);

        public void Openinvent() => managerInvent.TestOpenInvent();
    }
}