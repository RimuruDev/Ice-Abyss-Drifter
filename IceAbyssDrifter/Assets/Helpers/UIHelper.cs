using UnityEngine;

namespace RimuruDev.Helpers
{
    public sealed class UIHelper : MonoBehaviour
    {
        public void OpenAndClose(GameObject window) => window.SetActive(!window.activeInHierarchy);
    }
}