
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DeckIndexLeft : UdonSharpBehaviour
{
    public UdonBehaviour deckBehavior;
    public void OnLeftClick()
    {
        deckBehavior.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "IndexLeft");
    }
    public void OnRightClick()
    {
        deckBehavior.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "IndexRight");
    }

    public void OnIncrementClick()
    {
        deckBehavior.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "IncrementIndex");
    }

}
