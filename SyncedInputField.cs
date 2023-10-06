
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class SyncedInputField : UdonSharpBehaviour
{
    public InputField uiInputField;
    [UdonSynced, FieldChangeCallback(nameof(FieldValue))]
    string fieldValue;
    public void OnEndEdit()
    {
        if (uiInputField.text != FieldValue)
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            FieldValue = uiInputField.text;
            RequestSerialization();
        }
    }
    public string FieldValue
    {
        set
        {
            fieldValue = value;
            uiInputField.text = value;

        }
        get => fieldValue;
    }
}
