
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FireTrigger : UdonSharpBehaviour
{
    public string eventName;
    public UdonBehaviour target;
    public override void OnPlayerTriggerEnter(VRCPlayerApi myPlayer)
    {
        target.SendCustomEvent(eventName);
        Debug.Log(string.Format("sent {0} to {1}", eventName, target));
    }
}
