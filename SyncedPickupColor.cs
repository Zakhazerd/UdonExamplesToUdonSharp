
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SyncedPickupColor : UdonSharpBehaviour
{
    public Color fromColor = Color.black;
    public Renderer targetRenderer;
    public Color toColor = Color.black;
    public VRC_Pickup pickup;
    [UdonSynced]
    private Color syncColor = Color.black;
    void Update()
    {
        if(pickup.IsHeld && Networking.IsOwner(pickup.gameObject) )
        {
            syncColor = Color.LerpUnclamped(fromColor, toColor, Mathf.Sin(Time.time));
        }
        targetRenderer.material.SetColor("_Color", syncColor);
    }
}
