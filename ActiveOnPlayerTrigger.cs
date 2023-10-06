
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ActiveOnPlayerTrigger : UdonSharpBehaviour
{
    public GameObject target;
    public override void OnPlayerTriggerEnter(VRCPlayerApi myPlayer)
    {
        target.SetActive(true);
    }
    public override void OnPlayerTriggerExit(VRCPlayerApi myPlayer)
    {
        target.SetActive(false);

    }
}
