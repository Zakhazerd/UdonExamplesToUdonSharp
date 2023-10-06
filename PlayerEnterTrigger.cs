
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class PlayerEnterTrigger : UdonSharpBehaviour
{
    public Text textField;
    public override void OnPlayerTriggerEnter(VRCPlayerApi myPlayer)
    {
        textField.text = string.Format("{0} Entered", myPlayer.displayName);
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi myPlayer)
    {
        textField.text = string.Format("{0} Exited", myPlayer.displayName);
    }
}
