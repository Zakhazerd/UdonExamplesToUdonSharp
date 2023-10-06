
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class SyncedToggle : UdonSharpBehaviour
{
    public Toggle uiToggle;
    [UdonSynced, FieldChangeCallback(nameof(ToggleValue))]
    bool toggleValue = true;
    public void OnValueChanged()
    {
        if(uiToggle.isOn != ToggleValue)
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            ToggleValue = uiToggle.isOn;
            RequestSerialization();
        }
    }

    public bool ToggleValue
    {
        set
        {
            toggleValue = value;
            uiToggle.isOn = value;
            
        }
        get => toggleValue;
    }
}
