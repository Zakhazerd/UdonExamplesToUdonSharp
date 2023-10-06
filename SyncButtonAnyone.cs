﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class SyncButtonAnyone : UdonSharpBehaviour
{

    public Text uiText;
    [UdonSynced, FieldChangeCallback(nameof(ClickCount))]
    private int clickCount = 0;
    public void OnClick()
    {
        if (Networking.IsOwner(gameObject))
        {
            ClickCount++;
            RequestSerialization();
        }
        else
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "OnClick");
        }
    }

    public int ClickCount
    {
        set
        {
            clickCount = value;
            uiText.text = clickCount.ToString();
            Debug.Log("click count");
        }
        get => clickCount;
    }
}
