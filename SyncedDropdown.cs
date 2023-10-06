
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class SyncedDropdown : UdonSharpBehaviour
{
    public Dropdown uiDropdown;
    [UdonSynced, FieldChangeCallback(nameof(DropdownValue))]
    int dropdownValue;
    public void OnValueChanged()
    {
        if (uiDropdown.value != DropdownValue)
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            DropdownValue = uiDropdown.value;
            RequestSerialization();
        }
    }
    public int DropdownValue
    {
        set
        {
            dropdownValue = value;
            uiDropdown.value = value;

        }
        get => dropdownValue;
    }
}
