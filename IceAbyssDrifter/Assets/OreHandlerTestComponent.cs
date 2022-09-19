using System;
using UnityEngine;

public sealed class OreHandlerTestComponent : MonoBehaviour
{
    public Action<string> OnOreInteraction;

    public void OreHandler(string tag)
    {
        if (OnOreInteraction != null)
            OnOreInteraction.Invoke(tag);
    }

    public void CalculateOreData(string data)
    {

    }

    private void OnEnable()
    {
        OnOreInteraction += CalculateOreData;
    }

    private void OnDisable()
    {
        OnOreInteraction -= CalculateOreData;
    }
}
