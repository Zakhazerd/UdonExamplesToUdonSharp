
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnInteractEvent : UdonSharpBehaviour
{
    public UdonBehaviour target;
    public string eventName;
    void Interact()
    {
        target.SendCustomEvent(eventName);
    }
}
